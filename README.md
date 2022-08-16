# VR Speed Design

TP1 de la materia Realidad Virtual en ITBA.

# Configuración

## Android

La configuración en Android se hizo a partir del [siguiente tutorial](https://developers.google.com/cardboard/develop/unity/quickstart#configuring_android_project_settings), para resolver el problema en Play Mode de la escena Hello Cardboard se usó el siguiente fix:

```
#if !UNITY_EDITOR
        Api.UpdateScreenParams();
#endif
```
([source](https://stackoverflow.com/questions/71012488/please-initialize-cardboard-xr-loader-before-calling-this-function))

Para poder permitir el **Build & Run** es necesario activar **USB Debugging**, se puede hacer con el [siguiente tutorial](https://developer.android.com/studio/debug/dev-options).

# Notas

El proyecto fue creado a partir de la versión 2021.3.8f1 de Unit (Silicon, LTS).
