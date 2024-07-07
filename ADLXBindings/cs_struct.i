////////////////////////////////////////////////////////////////////////////////
// The cs_struct(C++type, C#type) macro maps a C++ struct to a C# struct. 
// Example:
//   %inline %{ struct Point2D { int X; int Y; }; %}
//   %cs_struct(Point2D, System.Drawing.Point)
// - %cs_struct and %cs_struct2 must be used at global scope. This is because,
//   to ensure that SWIG does not ignore variables that have the same name as 
//   the type (e.g. Foo Foo;), these macros use %ignore ::TYPE (where TYPE is
//   the first argument to the macro); SWIG does not support "%ignore struct 
//   TYPE" so "%ignore TYPE" would ignore both the type itself and any 
//   variables (or functions?) with the same name as the type.
// - Structures passed by value in C++ are passed by value in C# also
// - Pointer and reference arguments named "OUTPUT" or "result" in C are 
//   mapped to "out" arguments
// - const pointers and references are passed by value into the C# proxy
// - returning pointers/references is supported; P/Invoke will dereference 
//   the pointer
// - arrays/vectors/collections of structs are not supported
// - Other pointer and reference arguments are mapped to "ref" arguments
// - Structures can be returned from C++, but a bug in Microsoft's P/Invoke 
//   prevents structures larger than 8 bytes to be returned without special 
//   measures.
//   see http://www.nabble.com/Returning-structures-by-value-in-.NET-with-P-Invoke-(bonus:-passing-System.Drawing.Point)-t4262245.html
// - Sometimes Visual C++ cannot return C++ types correctly and the P/Invoke
//   call will fail. For example I was having trouble passing my 32-bit
//   fixed-point number class FixedPoint<BITS>, so I created %cs_struct2
//   which uses a pointer cast to fool C++ into thinking it is passing 
//   something else. For example I can reinterpret FixedPoint<4> as int 
//   using
//   %cs_struct2(FixedPoint<4>, int, FixedPoint4)
// - This has not been tested with Mono.
//
// The macro must be invoked BEFORE including the file that declares the type.
%define %cs_struct2_shared_part(TYPE, CTYPE, CSTYPE)
	%ignore ::TYPE;
	%typemap(ctype)                 TYPE*, TYPE&, TYPE[ANY]  %{ TYPE* %}
	%typemap(in)                    TYPE*, TYPE&, TYPE[ANY]  %{ $1 = $input; %}
	%typemap(varin)                 TYPE*, TYPE&, TYPE[ANY]  %{ $1 = $input; %}
	//%typemap(memberin)              TYPE*, TYPE&, TYPE[ANY]  %{ $1 = $input; %}
	%typemap(out, null="NULL")      TYPE*, TYPE&  %{ $result = $1; %}
	%typemap(varout, null="NULL")   TYPE*, TYPE&  %{ $result = $1; %}
	%typemap(memberout, null="NULL")TYPE*, TYPE&  %{ $result = $1; %}
	%typemap(imtype, out="IntPtr")  TYPE*, TYPE&  %{ref CSTYPE %}
	%typemap(imtype)                TYPE* OUTPUT, TYPE& OUTPUT %{ out CSTYPE %}
	%typemap(imtype, out="IntPtr")  TYPE[ANY] %{ CSTYPE[] %}
	%typemap(cstype, out="CSTYPE")  TYPE*, TYPE&  %{ref CSTYPE %}
	%typemap(cstype, out="CSTYPE")  TYPE* OUTPUT, TYPE& OUTPUT %{ out CSTYPE %}
	%typemap(cstype, out="IntPtr")  TYPE[ANY] %{ CSTYPE[] %}
	%typemap(cstype)                const TYPE*, const TYPE&   %{ CSTYPE %}
	%typemap(csin)                  TYPE*, TYPE&  %{ref $csinput %}
	%typemap(csin)                  TYPE* OUTPUT, TYPE& OUTPUT %{ out $csinput %}
	%typemap(csin)                  const TYPE*, const TYPE&   %{ref $csinput %}
	%typemap(csin)                  TYPE[ANY] %{ $csinput %}
	%typemap(csout, excode=SWIGEXCODE) TYPE*, TYPE& {
		IntPtr ptr = $imcall;$excode
		CSTYPE ret = (CSTYPE)Marshal.PtrToStructure(ptr, typeof(CSTYPE));
		return ret;
	}
	%typemap(csvarout, excode=SWIGEXCODE2) TYPE*, TYPE&
	%{
		get { 
			IntPtr ptr = $imcall;$excode
			CSTYPE ret = (CSTYPE)Marshal.PtrToStructure(ptr, typeof(CSTYPE));
			return ret;
		}
	%}
	%apply TYPE* OUTPUT { TYPE* result };
	%apply TYPE& OUTPUT { TYPE& result };
%enddef

#ifndef COMPACT_FRAMEWORK_COMPATIBLE
	%define %cs_struct2(TYPE, CTYPE, CSTYPE)
		%cs_struct2_shared_part(TYPE, CTYPE, CSTYPE)
		%typemap(ctype)                 TYPE          %{ CTYPE %}
		%typemap(in)                    TYPE          %{ $1 = *(TYPE*)&$input; %}
		%typemap(varin)                 TYPE          %{ $1 = *(TYPE*)&$input; %}
		//%typemap(memberin)              TYPE          %{ $1 = *(TYPE*)&$input; %}
		%typemap(out, null=#CTYPE "()") TYPE          %{ $result = *(CTYPE*)&$1; %}
		%typemap(varout, null=#CTYPE "()") TYPE       %{ $result = *(CTYPE*)&$1; %}
		%typemap(memberout, null=#CTYPE "()") TYPE    %{ $result = *(CTYPE*)&$1; %}
		%typemap(imtype)                TYPE          %{ CSTYPE %}
		%typemap(cstype)                TYPE          %{ CSTYPE %}
		%typemap(csin)                  TYPE          %{ $csinput %}
		%typemap(csout, excode=SWIGEXCODE) TYPE {
			CSTYPE ret = $imcall;$excode
			return ret;
		}
		%typemap(csvarout, excode=SWIGEXCODE2) TYPE
		%{
			get { 
				CSTYPE ret = $imcall;$excode
				return ret;
			}
		%}
	%enddef
#else
	%define %cs_struct2(TYPE, CTYPE, CSTYPE)
		%cs_struct2_shared_part(TYPE, CTYPE, CSTYPE)
		// In the .NET Compact Framework, only a pointer to a structure can be returned.
		// for the time being we'll use a thread-unsafe static variable...
		%typemap(ctype, out="CTYPE*")   TYPE          %{ CTYPE %}
		%typemap(in)                    TYPE          %{ $1 = *(TYPE*)&$input; %}
		%typemap(varin)                 TYPE          %{ $1 = *(TYPE*)&$input; %}
		//%typemap(memberin)              TYPE          %{ $1 = *(TYPE*)&$input; %}
		%typemap(out, null="NULL")      TYPE          %{ 
			// Not thread safe! (Only structure pointers can be returned from .NET Compact Framework)
			static CTYPE out_temp;
			out_temp = *(CTYPE*)&$1; 
			$result = &out_temp; 
		%}
		%typemap(varout, null="NULL")   TYPE          %{ 
			// Not thread safe! (Only structure pointers can be returned from .NET Compact Framework)
			static CTYPE out_temp;
			out_temp = *(CTYPE*)&$1; 
			$result = &out_temp; 
		%}
		%typemap(memberout, null="NULL") TYPE         %{ 
			// Not thread safe! (Only structure pointers can be returned from .NET Compact Framework)
			static CTYPE out_temp;
			out_temp = *(CTYPE*)&$1; 
			$result = &out_temp; 
		%}
		%typemap(imtype, out="IntPtr")  TYPE          %{CSTYPE %}
		%typemap(cstype)                TYPE          %{CSTYPE %}
		%typemap(csin)                  TYPE          %{$csinput %}
		%typemap(csout, excode=SWIGEXCODE) TYPE {
			IntPtr ptr = $imcall;$excode
			CSTYPE ret = (CSTYPE)Marshal.PtrToStructure(ptr, typeof(CSTYPE));
			return ret;
		}
		%typemap(csvarout, excode=SWIGEXCODE2) TYPE
		%{
			get {
				IntPtr ptr = $imcall;$excode
				CSTYPE ret = (CSTYPE)Marshal.PtrToStructure(ptr, typeof(CSTYPE));
				return ret;
			}
		%}
	%enddef
#endif

%define %cs_struct(TYPE, CSTYPE)
	%cs_struct2(TYPE, TYPE, CSTYPE)
%enddef
