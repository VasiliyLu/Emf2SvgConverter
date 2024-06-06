
using Emf2Svg;
using Svg;

namespace UnitTests;

public class WrapperTest
{
    [Fact]
    public void Test1()
    {
        //arrange
        byte[] bytes = File.ReadAllBytes("data\\scheme.emf");

        //act
        var svgBytes = Emf2SvgWrapper.ConvertEmfToSvg(bytes);
        
        //assert
        // create stream from svgString
        using var memoryStream = new MemoryStream(svgBytes);
        
        var svg = SvgDocument.Open<SvgDocument>(memoryStream);

        Assert.NotNull(svg);
    }
}