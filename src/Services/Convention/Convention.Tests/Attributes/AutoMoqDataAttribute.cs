using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Convention.BLL.Tests.Customatizations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Convention.BLL.Tests.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture();

                fixture.Customize(new ApiControllerCustomization())
                    .Customize(new AutoMoqCustomization())
                    .Customize<BindingInfo>(c => c.OmitAutoProperties());

                return fixture;
            })
        {
        }
    }
}