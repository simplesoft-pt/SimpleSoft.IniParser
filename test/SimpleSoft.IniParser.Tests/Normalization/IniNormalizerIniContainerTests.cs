﻿#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 João Simões
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System.Linq;
using SimpleSoft.IniParser.Impl;
using Xunit;

namespace SimpleSoft.IniParser.Tests.Normalization
{
    public class IniNormalizerIniContainerTests
    {
        #region IniContainer -> Global Comments

        [Fact]
        public void GivenANormalizerWithDefaultOptionsWhenNormalizedContainerThenEmptyGlobalCommentsMustBeRemoved()
        {
            var normalizer = new IniNormalizer();

            var source = ContainerForEmptyComments;
            var result = normalizer.Normalize(source);

            Assert.NotNull(result);
            Assert.NotEmpty(result.GlobalComments);
            Assert.False(result.GlobalComments.Any(string.IsNullOrWhiteSpace));
        }

        [Fact]
        public void GivenANormalizerWithDefaultOptionsWhenNormalizedContainerThenEmptyGlobalCommentsMustBeKept()
        {
            var normalizer = new IniNormalizer {Options = {IncludeEmptyComments = true}};

            var source = ContainerForEmptyComments;
            var result = normalizer.Normalize(source);

            Assert.NotNull(result);
            Assert.Equal(source.GlobalComments.Count, result.GlobalComments.Count);
            Assert.True(result.GlobalComments.Any(string.IsNullOrWhiteSpace));
        }

        #endregion

        #region Test Data

        private static readonly IniContainer ContainerForEmptyComments = new IniContainer
        {
            GlobalComments =
            {
                "comment",
                string.Empty,
                "comment",
                null
            }
        };

        #endregion
    }
}