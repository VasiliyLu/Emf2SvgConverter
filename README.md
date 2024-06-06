# Emf2Svg Library

## About

A cross-platform library (Windows, Linux) for converting EMF (Enhanced Metafile) files to SVG (Scalable Vector Graphics)
files.
Based on [libemf2svg](https://github.com/metanorma/libemf2svg) native C library.

## Nuget

[![Emf2SvgLibrary](https://img.shields.io/nuget/v/Emf2SvgLibrary?label=Emf2Svg%20Library&logoColor=white)](https://www.nuget.org/packages/Emf2SvgLibrary)

## How to use

There is one main class, `Emf2SvgConverter`, which is used to convert EMF files to SVG files.

Just call static method `Emf2SvgConverter.ConvertEmfToSvg(byte[] emfBytes)` to convert.