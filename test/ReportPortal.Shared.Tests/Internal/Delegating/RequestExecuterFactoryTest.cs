﻿using FluentAssertions;
using Moq;
using ReportPortal.Shared.Configuration;
using ReportPortal.Shared.Internal.Delegating;
using System;
using Xunit;

namespace ReportPortal.Shared.Tests.Internal.Delegating
{
    public class RequestExecuterFactoryTest
    {
        [Fact]
        public void ShouldThrowExceptionForNullConfiguration()
        {
            Action ctor = () => new RequestExecuterFactory(null);
            ctor.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ShouldCreateDefaultExponentialExecuter()
        {
            var configuration = new ConfigurationBuilder().Build();
            var factory = new RequestExecuterFactory(configuration);
            var executer = factory.Create();

            executer.Should().BeOfType<ExponentialRetryRequestExecuter>();
            var exponentialExecuter = executer as ExponentialRetryRequestExecuter;
            exponentialExecuter.MaxRetryAttemps.Should().Be(3);
            exponentialExecuter.BaseIndex.Should().Be(2);
        }

        [Fact]
        public void ShouldCreateLinearExecuter()
        {
            var configuration = new ConfigurationBuilder().Build();
            configuration.Values["Server:Retry:Strategy"] = "linear";
            var factory = new RequestExecuterFactory(configuration);
            var executer = factory.Create();

            executer.Should().BeOfType<LinearRetryRequestExecuter>();
            var exponentialExecuter = executer as LinearRetryRequestExecuter;
            exponentialExecuter.MaxRetryAttemps.Should().Be(3);
            exponentialExecuter.Delay.Should().Be(5000);
        }

        [Fact]
        public void ShouldThrowExceptionForUnknownStrategy()
        {
            var configuration = new ConfigurationBuilder().Build();
            configuration.Values["Server:Retry:Strategy"] = "any_unknown_value";
            var factory = new RequestExecuterFactory(configuration);

            factory.Invoking((f) => f.Create()).Should().Throw<ArgumentOutOfRangeException>().WithMessage("*any_unknown_value*");
        }
    }
}