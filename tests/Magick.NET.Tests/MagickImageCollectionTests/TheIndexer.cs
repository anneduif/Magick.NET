﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageCollectionTests
    {
        public class TheIndexer
        {
            [Fact]
            public void ShouldThrowExceptionWhenValueIsNull()
            {
                using (var images = new MagickImageCollection(Files.CirclePNG))
                {
                    Assert.Throws<InvalidOperationException>(() =>
                    {
                        images[0] = null;
                    });
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenCollectionAlreadyContainsItem()
            {
                var imageA = new MagickImage();
                var imageB = new MagickImage();

                using (var images = new MagickImageCollection(new[] { imageA, imageB }))
                {
                    Assert.Throws<InvalidOperationException>(() =>
                    {
                        images[0] = imageB;
                    });
                }
            }

            [Fact]
            public void ShouldNotThrowExceptionWhenImageIsSameImage()
            {
                var image = new MagickImage();

                using (var images = new MagickImageCollection(new[] { image }))
                {
                    images[0] = image;
                }
            }
        }
    }
}
