#!/bin/bash
if test "$OS" = "Windows_NT"
then
  # use .Net

  .paket/paket.bootstrapper.exe
  exit_code=$?
  if [ $exit_code -ne 0 ]; then
  	exit $exit_code
  fi

  .paket/paket.exe restore
  exit_code=$?
  if [ $exit_code -ne 0 ]; then
  	exit $exit_code
  fi

  packages/FAKE/tools/FAKE.exe $@ --fsiargs build.fsx
  
  src/Fable.Import.SharePoint/node_modules/.bin/fable.cmd
else
  # use mono
  mono .paket/paket.bootstrapper.exe
    
  exit_code=$?
  if [ $exit_code -ne 0 ]; then
    cd .paket
    wget https://github.com/fsprojects/Paket/releases/download/3.26.3/paket.exe
    wget https://github.com/fsprojects/Paket/releases/download/3.26.3/paket.targets  
    cd ..
  fi

  mono .paket/paket.exe restore
  exit_code=$?
  if [ $exit_code -ne 0 ]; then
  	exit $exit_code
  fi
  mono packages/FAKE/tools/FAKE.exe $@ --fsiargs -d:MONO build.fsx
  
  npm --version
  node --version
  
  chmod +x src/Fable.Import.SharePoint/node_modules/.bin/fable
  src/Fable.Import.SharePoint/node_modules/.bin/fable
fi
