﻿using System;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Domain.FilterTrees.StringFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees
{
    [TestFixture]
    public class FilterTreeNodeFactoryTests
    {
        private FilterTreeTreeNodeFactory _factory;
        private Mock<IBooleanFilterTreeFactory> _mockBooleanFactory;
        private Mock<IDateTimeFilterTreeFactory> _mockDateTimeFactory;
        private Mock<IFloatFilterTreeFactory> _mockFloatFactory;
        private Mock<IIntegerFilterTreeFactory> _mockIntegerFactory;
        private Mock<IStringFilterTreeFactory> _mockStringFactory;
        
        [SetUp]
        public void SetUp()
        {
            _mockBooleanFactory = new Mock<IBooleanFilterTreeFactory>();
            _mockDateTimeFactory = new Mock<IDateTimeFilterTreeFactory>();
            _mockFloatFactory = new Mock<IFloatFilterTreeFactory>();
            _mockIntegerFactory = new Mock<IIntegerFilterTreeFactory>();
            _mockStringFactory = new Mock<IStringFilterTreeFactory>();
            _factory = new FilterTreeTreeNodeFactory(
                _mockBooleanFactory.Object, 
                _mockDateTimeFactory.Object, 
                _mockFloatFactory.Object,
                _mockIntegerFactory.Object,
                _mockStringFactory.Object);
        }

        [Test]
        public void TestCreateRootShouldCreateBooleanFilterTreeRoot()
        {
            var column = new ColumnBuilder().WithType(typeof(Boolean)).Build();
            var node = new BooleanFilterTreeRoot(string.Empty);
            _mockBooleanFactory.Setup(p => p.CreateRoot(column)).Returns(node);
            var result = _factory.CreateRoot(column);
            Assert.That(result, Is.EqualTo(node));
        }

        [Test]
        public void TestCreateRootShouldCreateDateTimeFilterTreeRoot()
        {
            var column = new ColumnBuilder().WithType(typeof(DateTime)).Build();
            var node = new DateTimeFilterTreeRoot(string.Empty);
            _mockDateTimeFactory.Setup(p => p.CreateRoot(column)).Returns(node);
            var result = _factory.CreateRoot(column);
            Assert.That(result, Is.EqualTo(node));
        }

        [Test]
        public void TestCreateRootShouldCreateFloatFilterTreeRoot()
        {
            var column = new ColumnBuilder().WithType(typeof(Double)).Build();
            var node = new FloatFilterTreeRoot(string.Empty);
            _mockFloatFactory.Setup(p => p.CreateRoot(column)).Returns(node);
            var result = _factory.CreateRoot(column);
            Assert.That(result, Is.EqualTo(node));
        }

        [Test]
        public void TestCreateRootShouldCreateIntegerFilterTreeRoot()
        {
            var column = new ColumnBuilder().WithType(typeof(Int32)).Build();
            var node = new IntegerFilterTreeRoot(string.Empty);
            _mockIntegerFactory.Setup(p => p.CreateRoot(column)).Returns(node);
            var result = _factory.CreateRoot(column);
            Assert.That(result, Is.EqualTo(node));
        }

        [Test]
        public void TestCreateRootShouldCreateStringFilterTreeRoot()
        {
            var column = new ColumnBuilder().WithType(typeof(String)).Build();
            var node = new StringFilterTreeRoot(string.Empty);
            _mockStringFactory.Setup(p => p.CreateRoot(column)).Returns(node);
            var result = _factory.CreateRoot(column);
            Assert.That(result, Is.EqualTo(node));
        }

        [Test]
        public void TestCreateShouldThrowExceptionIfTypeIsNotSupported()
        {
            var column = new ColumnBuilder().WithType(typeof(Object)).Build();
            Assert.That(() => _factory.CreateRoot(column), Throws.ArgumentException);
        }
    }
}
