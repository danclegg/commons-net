﻿using FluentAssertions;
using ReportPortal.Client.Abstractions.Models;
using ReportPortal.Shared.Execution.Metadata;
using System;
using Xunit;

namespace ReportPortal.Shared.Tests.Execution.Metadata
{
    public class MetaAttributeFixture
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowExceptionWithIncorrectValue(string value)
        {
            Action act = () => new MetaAttribute(null, value);

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("a:b", "a", "b")]
        [InlineData("a:b:c", "a", "b:c")]
        [InlineData(":b", null, "b")]
        public void ShouldBeAbleToParseString(string value, string expectedKey, string expectedValue)
        {
            var metaAttribute = MetaAttribute.Parse(value);
            metaAttribute.Key.Should().Be(expectedKey);
            metaAttribute.Value.Should().Be(expectedValue);
        }

        [Fact]
        public void ShouldCastToItemAttribute()
        {
            var metaAttribute = new MetaAttribute("a", "b");
            ItemAttribute ia = metaAttribute;
            ia.Key.Should().Be("a");
            ia.Value.Should().Be("b");
        }
    }
}
