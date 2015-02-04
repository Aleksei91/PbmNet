﻿using System;
using System.Collections.Generic;
using System.IO;

namespace RavuAlHemio.PbmNet
{
    /// <summary>
    /// Implemented by classes which help assemble specializations of <see cref="NetpbmImage{TPixelComponent}"/>.
    /// </summary>
    public interface IImageFactory<TPixelComponent>
    {
        /// <summary>
        /// The pixel component value for "on" pixels. Simultaneously the highest component value in bitmap (binary)
        /// images.
        /// </summary>
        TPixelComponent BitmapOnPixelComponentValue { get; }

        /// <summary>
        /// The pixel component value zero. The "off" value in bitmap (binary) images, and the "none of this component"
        /// value in images with a higher bit depth.
        /// </summary>
        TPixelComponent ZeroPixelComponentValue { get; }

        /// <summary>
        /// Parses the highest component value from a string of decimal digits.
        /// </summary>
        /// <returns>The highest component value.</returns>
        /// <param name="highestComponentValueString">The highest component string value to parse.</param>
        /// <exception cref="FormatException">Thrown if parsing fails.</exception>
        TPixelComponent ParseHighestComponentValue(string highestComponentValueString);

        /// <summary>
        /// Parses a component value from a string of decimal digits.
        /// </summary>
        /// <returns>The component value.</returns>
        /// <param name="componentValueString">The component value string to parse.</param>
        /// <exception cref="FormatException">Thrown if parsing fails.</exception>
        TPixelComponent ParseComponentValue(string componentValueString);

        /// <summary>
        /// Reads a row from the stream. A row consists of <paramref name="width"/> times
        /// <paramref name="componentCount"/> values, each of a value from <value>0</value> to
        /// <paramref name="highestComponentValue"/>.
        /// </summary>
        /// <param name="stream">The stream to read a row from.</param>
        /// <param name="width">The width of the image being read.</param>
        /// <param name="componentCount">The number of components per pixel.</param>
        /// <param name="highestComponentValue">The highest value a pixel component can assume.</param>
        /// <exception cref="EndOfStreamException">Thrown if the end of the stream is reached before enough components
        /// could be read.</exception>
        IEnumerable<TPixelComponent> ReadRow(Stream stream, int width, int componentCount, TPixelComponent highestComponentValue);

        /// <summary>
        /// Creates a new image.
        /// </summary>
        /// <param name="width">The width of the image.</param>
        /// <param name="height">The height of the image.</param>
        /// <param name="highestComponentValue">The highest value for a pixel component.</param>
        /// <param name="components">The components making up this image.</param>
        /// <param name="pixelData">The pixel data rows.</param>
        /// <returns>The new image.</returns>
        NetpbmImage<TPixelComponent> MakeImage(int width, int height, TPixelComponent highestComponentValue,
            IEnumerable<Component> components, IEnumerable<IEnumerable<TPixelComponent>> pixelData);
    }
}
