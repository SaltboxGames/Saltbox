# Saltbox
[![openupm](https://img.shields.io/npm/v/com.saltboxgames.saltbox?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.saltboxgames.saltbox/)

This is a library of common assets and utilities used by Saltbox Games for Unity 2019.3^ 

## Usage
Assets and scripts are available under the `saltbox` namespace.
*This documentation is incomplete*
- [Storage](./Storage)

## Installing from **OpenUPM**
You can easily install this package using OpenUPM CLI
```
openupm add com.saltboxgames.saltbox
```
**Note**: 
this method requires `Node 12` and you can install OpenUPM using 
```
npm install -g openupm-cli
```

## Installing from **OpenUPM** _(without cli)_
You can install this package by adding the following to your package manifest
```
"dependencies": {
    "com.saltboxgames.saltbox": "{VERSION}",
    ...
}
"scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.openupm",
        "com.saltboxgames.saltbox"
      ]
    }
  ]
```

## Installing from **GitHub**
You can also install this library from GitHub using Unity's Package Manager.
- Open Package Manager
- Select Add package from git URL
- `https://github.com/SaltboxGames/Saltbox.git`

Alternatively if you wish to target a specific branch you can
- Open `{PROJECT}\Packages\manifest.json`
- Add  `"com.saltboxgames.saltbox": "https://github.com/saltboxgames/saltbox.git#[BRANCH-NAME]"` 
    as a dependency

**Note**: 
this method will require you to remove and re add the package to update.
