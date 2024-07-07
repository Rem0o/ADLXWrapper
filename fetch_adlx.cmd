@echo off
SET repo_path=".\ADLX"
SET repo_url="https://github.com/GPUOpen-LibrariesAndSDKs/ADLX.git"

IF NOT EXIST %repo_path% (
    echo Repository does not exist, cloning now...
    git clone %repo_url% %repo_path%
) ELSE (
    echo Repository exists, fetching and pulling latest changes...
    cd /d %repo_path%
    git fetch --all
    git pull
)