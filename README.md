
# Saltbox
[![Build Status](https://ci.saltboxgames.com/api/badges/SaltboxGames/Saltbox/status.svg)](https://ci.saltboxgames.com/SaltboxGames/Saltbox)

Common Utils and Extensions used in Unity. 

`using Saltbox;`

### Installing
This Library can be installed by adding the following to your projects package manifest `{PROJECT}\Packages\manifest.json`

```json
"scopedRegistries": [
    {
      "name": "SaltboxGames",
      "url": "http://pkg.saltboxgames.com:4873/",
      "scopes": [
        "com.saltboxgames"
      ]
    }
  ],
```
```json
"dependencies": {
    "com.saltboxgames.saltbox": "0.1.3",
    ...
}
```

If you wish to use experimental or unfinished assets you can use the `develop` branch instead.

```json
"dependencies": {
    "com.saltboxgames.saltbox": "https://github.com/saltboxgames/saltbox.git#develop",
    ...
}
```