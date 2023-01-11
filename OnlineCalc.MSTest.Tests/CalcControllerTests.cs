using OnlineCalc.Controllers;

namespace OnlineCalc.MSTest.Tests
{
    [TestClass]
    public class CalcControllerTests
    {
        [TestMethod]
        public void Sum_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 14.0;

            // Act
            var result = controller.Sum(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [DataTestMethod]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void Sum_CheckOutOfDoubleRange_ShouldThrowException(double a, double b)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act and Assert
            Assert.ThrowsException<Exception>(() => controller.Sum(request));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetSumRequests), DynamicDataSourceType.Method)]
        public void Sum_Multiple_CheckExpectedResult(double a, double b, double expected)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act
            var result = controller.Sum(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [TestMethod]
        public void Difference_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 6.0;

            // Act
            var result = controller.Difference(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [DataTestMethod]
        [DynamicData("Data", typeof(CalcData), DynamicDataSourceType.Property)]
        public void Difference_Multiple_CheckExpectedResult(double a, double b, double expected)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act
            var result = controller.Difference(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [TestMethod]
        public void Multiplication_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 40.0;

            // Act
            var result = controller.Multiplication(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [DataTestMethod]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue)]
        public void Multiplication_CheckOutOfDoubleRange_ShouldThrowException(double a, double b)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act and Assert
            Assert.ThrowsException<Exception>(() => controller.Multiplication(request));
        }

        [TestMethod]
        public void Division_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 2.5;

            // Act
            var result = controller.Division(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [TestMethod]
        public void Division_DivideByZero_ShouldThrowDivideByZeroException()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 0.0);

            // Act and Asset
            Assert.ThrowsException<DivideByZeroException>(() => controller.Division(request));
        }

        [TestMethod]
        public void Power_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 10000;

            // Act
            var result = controller.Power(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [DataTestMethod]
        [DataRow(0.0)]
        [DataRow(1.0)]
        [DataRow(12.0)]
        [DataRow(24.0)]
        [DataRow(23684325.0)]
        [DataRow(-14141.0)]
        public void Power_PowerByZero_ShouldReturnOne(double a)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, 0);
            var expected = 1;

            // Act
            var result = controller.Power(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [DataTestMethod]
        [DataRow(double.MaxValue, double.MaxValue)]
        [DataRow(double.MinValue, double.MaxValue)]
        [DataRow(double.MaxValue, 2)]
        [DataRow(double.MinValue, 2)]
        public void Power_CheckOutOfDoubleRange_ShouldThrowException(double a, double b)
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(a, b);

            // Act and Assert
            Assert.ThrowsException<Exception>(() => controller.Power(request));
        }

        [TestMethod]
        public void Sqrt_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcARequest(10.0);
            var expected = 3.16227766017;

            // Act
            var result = controller.Sqrt(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        [TestMethod]
        public void Remainder_CheckExpectedResult()
        {
            // Arrange
            var controller = new CalcController();
            var request = new CalcABRequest(10.0, 4.0);
            var expected = 2.0;

            // Act
            var result = controller.Remainder(request);

            // Assert
            Assert.AreEqual(expected, result.Value, 0.001);
        }

        public static IEnumerable<object[]> GetSumRequests ()
        {
            yield return From(-127.347, 3696.837, 3569.49);
            yield return From(-3080.393, 3628.072, 547.6790000000001);
            yield return From(3921.732, 13144.53, 17066.262000000002);
            yield return From(8522.716, 6500.548, 15023.264);
            yield return From(-4434.076, 10089.725, 5655.649);
            yield return From(4013.68, 8789.014, 12802.694);
            yield return From(1807.811, 6166.993, 7974.804);
            yield return From(6673.057, -1603.67, 5069.387);
            yield return From(11614.252, 3014.977, 14629.229);
            yield return From(2025.134, -1342.644, 682.49);
            yield return From(2862.668, 11578.554, 14441.222);
            yield return From(2152.209, 2286.392, 4438.601);
            yield return From(12909.791, -4761.568, 8148.222999999999);
            yield return From(874.742, -159.782, 714.9599999999999);
            yield return From(9035.949, 10315.512, 19351.461000000003);
            yield return From(14920.23, 13176.008, 28096.237999999998);
            yield return From(2173.809, 6891.573, 9065.382000000001);
            yield return From(11005.781, -853.688, 10152.093);
            yield return From(-1959.285, 3655.629, 1696.3439999999998);
            yield return From(1143.299, 1890.997, 3034.2960000000003);
            yield return From(7377.959, 8202.661, 15580.619999999999);
            yield return From(7304.206, -3730.206, 3574);
            yield return From(7994.128, 1049.334, 9043.462);
            yield return From(12461.493, 14040.068, 26501.561);
            yield return From(6213.666, 208.358, 6422.024);
            yield return From(13155.891, 1012.066, 14167.957);
            yield return From(12382.255, 1069.971, 13452.225999999999);
            yield return From(12249.21, 3805.083, 16054.293);
            yield return From(1331.381, 3908.475, 5239.856);
            yield return From(-3077.004, 9129.137, 6052.133000000001);
            yield return From(-2133.222, 7962.143, 5828.921);
            yield return From(11522.835, 12556.468, 24079.303);
            yield return From(10952.402, 1215.915, 12168.317);
            yield return From(376.481, 4863.075, 5239.556);
            yield return From(1454.202, 10106.949, 11561.151);
            yield return From(-4255.26, -2134.222, -6389.482);
            yield return From(7340.421, 5868.472, 13208.893);
            yield return From(11505.08, 10532.751, 22037.831);
            yield return From(9066.892, 9290.27, 18357.162);
            yield return From(5002.143, 7186.915, 12189.058);
            yield return From(6113.691, 5385.826, 11499.517);
            yield return From(11436.851, 4795.465, 16232.316);
            yield return From(-2787.203, 6817.554, 4030.351);
            yield return From(1195.159, 10253.352, 11448.511);
            yield return From(3892.081, 5457.767, 9349.848);
            yield return From(13172.949, 5337.717, 18510.666);
            yield return From(-421.98, 13868.238, 13446.258);
            yield return From(3902.042, 923.871, 4825.913);
            yield return From(8551.546, 14143.116, 22694.662);
            yield return From(-2247.574, 5659.651, 3412.0769999999998);
            yield return From(-4887.927, 12151.726, 7263.799000000001);
            yield return From(14886.028, -91.96, 14794.068000000001);
            yield return From(13318.67, 5044.827, 18363.497);
            yield return From(-4827.968, 1447.707, -3380.2609999999995);
            yield return From(13999.323, 13196.509, 27195.832000000002);
            yield return From(1859.428, 971.556, 2830.9840000000004);
            yield return From(14221.241, -1398.402, 12822.839);
            yield return From(13777.719, 4003.848, 17781.567);
            yield return From(2001.553, -3727.152, -1725.599);
            yield return From(6656.281, 14170.342, 20826.623);
            yield return From(-3526.934, 854.842, -2672.092);
            yield return From(-2712.29, -687.973, -3400.263);
            yield return From(2094.51, 3305.946, 5400.456);
            yield return From(13726.566, 9056.741, 22783.307);
            yield return From(13332.514, 2442.818, 15775.331999999999);
            yield return From(12308, 10409.529, 22717.529000000002);
            yield return From(6921.802, -4502.685, 2419.1169999999993);
            yield return From(3340.207, 5221.382, 8561.589);
            yield return From(-4278.016, 6259.448, 1981.4320000000007);
            yield return From(1134.601, 12451.856, 13586.457);
            yield return From(-2206.47, 4499.563, 2293.0930000000003);
            yield return From(5103.629, 10129.424, 15233.053);
            yield return From(13435.224, 2319.384, 15754.608);
            yield return From(3413.968, 6507.884, 9921.851999999999);
            yield return From(6498.989, 14985.778, 21484.767);
            yield return From(7203.86, 7047.865, 14251.724999999999);
            yield return From(7074.548, 9701.334, 16775.882);
            yield return From(6745.337, 6835.41, 13580.747);
            yield return From(4912.947, -4203.771, 709.1760000000004);
            yield return From(-558.654, -3826.492, -4385.146000000001);
            yield return From(3169.24, 11031.161, 14200.401);
            yield return From(1756.13, 5476.037, 7232.167);
            yield return From(3674.7, 873.982, 4548.682);
            yield return From(10514.309, -2950.389, 7563.919999999999);
            yield return From(11933.25, 9530.769, 21464.019);
            yield return From(11946.409, -680.112, 11266.297);
            yield return From(-789.082, -4455.631, -5244.713000000001);
            yield return From(14725.904, -1396.597, 13329.307);
            yield return From(-615.798, 768.023, 152.22500000000002);
            yield return From(-815.145, 12375.057, 11559.912);
            yield return From(9697.407, -4195.453, 5501.953999999999);
            yield return From(11664.187, -1173.857, 10490.33);
            yield return From(-3944.922, 8761.726, 4816.804);
            yield return From(2497.504, -1500.597, 996.9069999999999);
            yield return From(1539.394, -3698.946, -2159.5519999999997);
            yield return From(4276.879, 11342.7, 15619.579000000002);
            yield return From(13390.788, 10188.105, 23578.893);
            yield return From(-4458.193, -4603.296, -9061.489000000001);
            yield return From(-3862.617, 14611.781, 10749.164);
            yield return From(11073.168, 2798.506, 13871.673999999999);

            static object[] From(double a, double b, double expected) => new object[] { a, b, expected };
        }
    }
}