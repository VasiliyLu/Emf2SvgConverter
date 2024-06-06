using System.Runtime.InteropServices;

namespace Emf2Svg;

[StructLayout(LayoutKind.Sequential)]
public struct GeneratorOptions()
{
    [MarshalAs(UnmanagedType.LPStr)]
    public string nameSpace = ""; // SVG namespace (the '<something>:' before each fields)

    [MarshalAs(UnmanagedType.I1)] public bool verbose = false; // Verbose mode, output fields and fields values if True

    [MarshalAs(UnmanagedType.I1)] public bool emfplus = false; // Handle emf+ records or not

    [MarshalAs(UnmanagedType.I1)] public bool svgDelimiter = true; // Draw svg document delimiter or not

    public double imgHeight = 0; // Height of the target image
    public double imgWidth = 0; // Width of the target image
}

public class Emf2SvgWrapper
{
    [DllImport("emf2svg", CallingConvention = CallingConvention.Cdecl)]
    private static extern nint emf2svg(byte[] contents, nuint length, out nint outSvg, out nuint outLength,
        ref GeneratorOptions options);

    public static byte[] ConvertEmfToSvg(byte[] contents)
    {
        return ConvertEmfToSvg(contents, new GeneratorOptions());
    }

    public static byte[] ConvertEmfToSvg(byte[] contents, GeneratorOptions options)
    {
        nint outSvgPtr;
        nuint outSvgLength;

        var result = emf2svg(contents, (nuint)contents.Length, out outSvgPtr, out outSvgLength, ref options);
        if (result != 1)
        {
            throw new Exception($"Conversion failed with error code {result}");
        }

        try
        {
            // Копируем данные из неуправляемой памяти
            var outSvgBytes = new byte[(int)outSvgLength];
            Marshal.Copy(outSvgPtr, outSvgBytes, 0, (int)outSvgLength);

            return outSvgBytes;
        }
        finally
        {
            // Освобождаем неуправляемую память, если библиотека это требует (проверьте документацию библиотеки)
            Marshal.FreeHGlobal(outSvgPtr);
        }
    }
}