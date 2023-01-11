using OnlineCalc.Controllers;

namespace OnlineCalc.XUnit.Tests
{
    public class CalcControllerTests
    {
        [Fact]
        public void Sum_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 14.0;

            // Act
            var result = controller.Sum(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Theory]
        [InlineData(double.MaxValue, double.MaxValue)]
        [InlineData(double.MinValue, double.MinValue)]
        public void Sum_CheckOutOfDoubleRange_ShouldThrowException(double a, double b)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act and Assert
            Assert.Throws<Exception>(() => controller.Sum(request));
        }

        [Theory]
        [MemberData(nameof(GetSumRequests), parameters: 100)]
        public void Sum_Multiple_CheckExpectedResult(double a, double b, double expected)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act
            var result = controller.Sum(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Fact]
        public void Difference_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 6.0;

            // Act
            var result = controller.Difference(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Theory]
        [MemberData(nameof(CalcData.Data), MemberType = typeof(CalcData))]
        public void Difference_Multiple_CheckExpectedResult(double a, double b, double expected)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act
            var result = controller.Difference(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Fact]
        public void Multiplication_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 40.0;

            // Act
            var result = controller.Multiplication(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Theory]
        [InlineData(double.MaxValue, double.MaxValue)]
        [InlineData(double.MinValue, double.MinValue)]
        public void Multiplication_CheckOutOfDoubleRange_ShouldThrowException(double a, double b)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act and Assert
            Assert.Throws<Exception>(() => controller.Multiplication(request));
        }

        [Fact]
        public void Division_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 2.5;

            // Act
            var result = controller.Division(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Fact]
        public void Division_DivideByZero_ShouldThrowDivideByZeroException()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 0.0);

            // Act and Asset
            Assert.Throws<DivideByZeroException>(() => controller.Division(request));
        }

        [Fact]
        public void Power_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 10000;

            // Act
            var result = controller.Power(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(1.0)]
        [InlineData(12.0)]
        [InlineData(24.0)]
        [InlineData(23684325.0)]
        [InlineData(-14141.0)]
        public void Power_PowerByZero_ShouldReturnOne(double a)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, 0);
            var expected = 1;

            // Act
            var result = controller.Power(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Theory]
        [InlineData(double.MaxValue, double.MaxValue)]
        [InlineData(double.MinValue, double.MaxValue)]
        [InlineData(double.MaxValue, 2)]
        [InlineData(double.MinValue, 2)]
        public void Power_CheckOutOfDoubleRange_ShouldThrowException(double a, double b)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act and Assert
            Assert.Throws<Exception>(() => controller.Power(request));
        }

        [Fact]
        public void Sqrt_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcARequest(10.0);
            var expected = 3.16227766017;

            // Act
            var result = controller.Sqrt(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        [Fact]
        public void Remainder_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 2.0;

            // Act
            var result = controller.Remainder(request);

            // Assert
            Assert.Equal(expected, result.Value, 3);
        }

        public static IEnumerable<object[]> GetSumRequests(int numTests)
        {
            var allData = new List<object[]>
            {
                From(-4748.029, 3435.16, -1312.8690000000006),
                From(2188.866, -3811.667, -1622.801),
                From(2265.628, 2365.878, 4631.506),
                From(14024.691, 12725.033, 26749.724000000002),
                From(14757.644, 8588.441, 23346.085),
                From(4281.469, 9482.696, 13764.165),
                From(762.433, 1951.664, 2714.0969999999998),
                From(-199.02, 978.666, 779.6460000000001),
                From(14952.947, -531.773, 14421.174),
                From(12347.488, 10410.928, 22758.415999999997),
                From(8550.523, 9762.735, 18313.258),
                From(1748.652, -4825.444, -3076.7920000000004),
                From(11474.538, 12879.857, 24354.395),
                From(8100.821, 2474.227, 10575.047999999999),
                From(-4408.569, 7794.172, 3385.602999999999),
                From(1555.414, 2107.729, 3663.143),
                From(7456.426, 7421.393, 14877.819),
                From(5655.546, -3791.712, 1863.8340000000003),
                From(8562.638, 5136.48, 13699.118),
                From(5683.006, -2265.51, 3417.496),
                From(1215.706, 5032.102, 6247.808),
                From(1289.017, 10591.77, 11880.787),
                From(2084.877, 1923.939, 4008.816),
                From(-927.245, -4312.261, -5239.506),
                From(1040.977, -1205.517, -164.53999999999996),
                From(1105.999, 6786.395, 7892.394),
                From(10536.546, -1497.345, 9039.201000000001),
                From(-949.623, -2125.917, -3075.54),
                From(12220.504, 10307.052, 22527.556),
                From(-4819.191, -2815.375, -7634.566),
                From(2567.895, 924.302, 3492.197),
                From(-3553.714, 10855.257, 7301.543),
                From(707.358, 12747.752, 13455.11),
                From(4361.866, 4598.54, 8960.405999999999),
                From(14543.683, 10747.221, 25290.904000000002),
                From(2859.902, 11987.835, 14847.737),
                From(11485.124, 2605.059, 14090.183),
                From(8873.18, -1343.546, 7529.634),
                From(-2072.114, 1528.404, -543.71),
                From(8721.672, -4134.647, 4587.025000000001),
                From(13935.018, 3292.812, 17227.83),
                From(3559.146, 9270.082, 12829.228000000001),
                From(3487.047, 9193.021, 12680.068000000001),
                From(-358.433, 4743.597, 4385.164),
                From(-141.291, -464.492, -605.783),
                From(9726.649, 10342.951, 20069.6),
                From(-554.852, -2464.526, -3019.3779999999997),
                From(14398.344, -1179, 13219.344),
                From(7399.26, -1412.05, 5987.21),
                From(8769.619, 8178.789, 16948.408),
                From(-885.865, 11808.562, 10922.697),
                From(6524.272, 1387.424, 7911.696),
                From(-1304.971, 2538.783, 1233.812),
                From(12484.365, 10658.762, 23143.127),
                From(11701.025, -1184.054, 10516.971),
                From(8324.012, 13592.315, 21916.327),
                From(8755.616, 8677.513, 17433.129),
                From(8195.121, 12888.957, 21084.078),
                From(13964.387, 6721.599, 20685.986),
                From(13315.667, 13326.01, 26641.677),
                From(4212.448, 14699.694, 18912.142),
                From(-4725.902, -4494.883, -9220.785),
                From(424.809, -2215.252, -1790.443),
                From(13087.481, 14389.008, 27476.489),
                From(8904.95, 6693.342, 15598.292000000001),
                From(9341.997, -3476.597, 5865.4),
                From(5527.339, 8963.924, 14491.263),
                From(11686.701, 3607.517, 15294.217999999999),
                From(12713.993, -884.575, 11829.418),
                From(14617.842, -3516.955, 11100.887),
                From(-3651.26, 137.673, -3513.5870000000004),
                From(-4801.896, 9730.412, 4928.5160000000005),
                From(8811.914, 4968.6, 13780.514000000001),
                From(2780.728, 8745.908, 11526.635999999999),
                From(484.301, 977.584, 1461.885),
                From(14524.369, 13762.535, 28286.904000000002),
                From(9814.75, 12249.302, 22064.052),
                From(-4265.901, 6100.186, 1834.2849999999999),
                From(-1611.473, -1603.119, -3214.5919999999996),
                From(-1315.436, 11309.92, 9994.484),
                From(12618.659, 8524.61, 21143.269),
                From(11559.401, 12557.53, 24116.931),
                From(785.17, 9958.355, 10743.525),
                From(1562.145, 7937.522, 9499.667),
                From(3746.825, 9635.48, 13382.305),
                From(1175.16, -4037.675, -2862.5150000000003),
                From(-427.309, 14105.964, 13678.655),
                From(12655.245, 627.512, 13282.757000000001),
                From(-2656.299, -3304.299, -5960.598),
                From(14693.591, 12328.984, 27022.575),
                From(14257.846, 12668.206, 26926.052),
                From(-4064.457, 9782.211, 5717.753999999999),
                From(7620.693, 10500.884, 18121.577),
                From(6466.4, -3662.15, 2804.2499999999995),
                From(10125.211, 1561.569, 11686.779999999999),
                From(2475.258, 12184.959, 14660.217),
                From(-4371.329, 11680.639, 7309.3099999999995),
                From(10227.761, 9415.753, 19643.514000000003),
                From(11408.746, 3283.074, 14691.82),
                From(1264.365, 9253.456, 10517.821)
            };

            return allData.Take(numTests);

            static object[] From(double a, double b, double expected) => new object[] { a, b, expected };
        }
    }
}