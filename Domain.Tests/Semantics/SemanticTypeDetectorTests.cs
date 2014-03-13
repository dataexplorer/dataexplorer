using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Semantics;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Semantics
{
    [TestFixture]
    public class SemanticTypeDetectorTests
    {
        private SemanticTypeDetector _detector;
        private Type _dataType;

        [SetUp]
        public void SetUp()
        {
            _detector = new SemanticTypeDetector();
            _dataType = typeof (string);
        }

        [Test]
        public void TestDetectorShouldDetectUrlAsUri()
        {
            var values = new List<object> { "http://www.test.com" };
            var result = _detector.Detect(_dataType, values);
            Assert.That(result, Is.EqualTo(SemanticType.Uri));
        }

        [Test]
        public void TestDetectorShouldDetectFilePathAsUri()
        {
            var values = new List<object> { @"C:\Test" };
            var result = _detector.Detect(_dataType, values);
            Assert.That(result, Is.EqualTo(SemanticType.Uri));
        }

        [Test]
        public void TestDetectorShouldReturnUnknownIfSementicTypeNotDetected()
        {
            var values = new List<object> { "Unknown" };
            var result = _detector.Detect(_dataType, values);
            Assert.That(result, Is.EqualTo(SemanticType.Unknown));
        }
    }
}
