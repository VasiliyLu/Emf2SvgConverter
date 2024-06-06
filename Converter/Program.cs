// See https://aka.ms/new-console-template for more information

using Emf2Svg;

// read inputFile name parameter
var inputFile = args[0];


var emfBytes = File.ReadAllBytes(inputFile);
var svgBytes = Emf2SvgWrapper.ConvertEmfToSvg(emfBytes, new GeneratorOptions());
// save svg to inputFile name parameter with .svg extension
File.WriteAllBytes(inputFile + ".svg", svgBytes);

Console.WriteLine("Done");