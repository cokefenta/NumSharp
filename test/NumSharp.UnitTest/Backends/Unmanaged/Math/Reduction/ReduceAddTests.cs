﻿using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumSharp.Backends;

namespace NumSharp.UnitTest.Backends.Unmanaged.Math.Reduction
{
    [TestClass]
    public class ReduceAddTests
    {
        [TestMethod]
        public void Case0_Scalar()
        {
            var a = NDArray.Scalar(1);
            var ret = a.sum();
            ret.Shape.IsScalar.Should().BeTrue();
            ret.GetInt32(0).Should().Be(1);
        }               
        
        [TestMethod]
        public void Case0_Scalar_Axis0()
        {
            var a = NDArray.Scalar(1);
            var ret = a.sum(0);
            ret.Shape.IsScalar.Should().BeTrue();
            ret.GetInt32(0).Should().Be(1);
        }        
        
        [TestMethod]
        public void Case1_Elementwise()
        {
            var a = np.ones((3, 3, 3), NPTypeCode.Int32);
            var ret = a.sum();
            ret.Shape.IsScalar.Should().BeTrue();
            ret.GetInt32(0).Should().Be(3 * 3 * 3);
        }

        [TestMethod]
        public void Case1_Axis0()
        {
            var a = np.ones((3, 3, 3), NPTypeCode.Int32);
            var ret = a.sum(0);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(9);
            ret.Shape.Should().Be(new Shape(3, 3));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }

        [TestMethod]
        public void Case1_Axis1()
        {
            var a = np.ones((3, 3, 3), NPTypeCode.Int32);
            var ret = a.sum(1);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(9);
            ret.Shape.Should().Be(new Shape(3, 3));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }

        [TestMethod]
        public void Case1_Axis2()
        {
            var a = np.ones((3, 3, 3), NPTypeCode.Int32);
            var ret = a.sum(2);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(9);
            ret.Shape.Should().Be(new Shape(3, 3));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }

        [TestMethod]
        public void Case1_Axis_minus1()
        {
            var a = np.ones((3, 3, 3), NPTypeCode.Int32);
            var ret = a.sum(-1);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(9);
            ret.Shape.Should().Be(new Shape(3, 3));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }

        [TestMethod]
        public void Case1_Axis2_keepdims()
        {
            var a = np.ones((3, 3, 3), NPTypeCode.Int32);
            var ret = a.sum(2, keepdims: true);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(9);
            ret.Shape.Should().Be(new Shape(3, 3, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }

        [TestMethod]
        public void Case1_Axis_minus1_keepdims()
        {
            var a = np.ones((3, 3, 3), NPTypeCode.Int32);
            var ret = a.sum(-1, keepdims: true);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(9);
            ret.Shape.Should().Be(new Shape(3, 3, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }

        [TestMethod]
        public void Case1_Axis_1_keepdims()
        {
            var a = np.ones((3, 3, 3), NPTypeCode.Int32);
            var ret = a.sum(1, keepdims: true);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(9);
            ret.Shape.Should().Be(new Shape(3, 1, 3));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }


        [TestMethod]
        public void Case2_Elementwise()
        {
            var a = np.ones((2, 1, 3, 5, 1), np.int32);

            var ret = a.sum();
            ret.Shape.IsScalar.Should().BeTrue();
            ret.GetInt32(0).Should().Be(2 * 1 * 3 * 5 * 1);
        }

        [TestMethod]
        public void Case2_Axis0()
        {
            var a = np.ones((2, 1, 3, 5, 1), np.int32);
            var ret = a.sum(0);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(15);
            ret.Shape.Should().Be(new Shape(1, 3, 5, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(2);
        }

        [TestMethod]
        public void Case2_Axis1()
        {
            var a = np.ones((2, 1, 3, 5, 1), np.int32);
            var ret = a.sum(1);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(30);
            ret.Shape.Should().Be(new Shape(2, 3, 5, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(1);
        }

        [TestMethod]
        public void Case2_Axis2()
        {
            var a = np.ones((2, 1, 3, 5, 1), np.int32);
            var ret = a.sum(2);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(10);
            ret.Shape.Should().Be(new Shape(2, 1, 5, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }

        [TestMethod]
        public void Case2_Axis4()
        {
            var a = np.ones((2, 1, 3, 5, 1), np.int32);
            var ret = a.sum(4);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(30);
            ret.Shape.Should().Be(new Shape(2, 3, 5, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(1);
        }

        [TestMethod]
        public void Case2_Axis_minus1()
        {
            var a = np.ones((2, 1, 3, 5, 1), np.int32);
            var ret = a.sum(4);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(30);
            ret.Shape.Should().Be(new Shape(2, 3, 5, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(1);
        }

        [TestMethod]
        public void Case2_Axis2_keepdims()
        {
            var a = np.ones((2, 1, 3, 5, 1), np.int32);
            var ret = a.sum(2, keepdims: true);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(10);
            ret.Shape.Should().Be(new Shape(2, 1, 1, 5, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(3);
        }

        [TestMethod]
        public void Case2_Axis_minus1_keepdims()
        {
            var a = np.ones((2, 1, 3, 5, 1), np.int32);
            var ret = a.sum(-1, keepdims: true);
            ret.Shape.IsScalar.Should().BeFalse();
            ret.size.Should().Be(30);
            ret.Shape.Should().Be(new Shape(2, 1, 3, 5, 1));
            ret.Cast<int>().Should().AllBeEquivalentTo(1);
        }
    }
}
