﻿using System.Collections.Generic;

namespace RavuAlHemio.PbmNet
{
    /// <summary>
    /// An in-memory representation of a Netpbm image with 8 bits per pixel component. This is probably the most common
    /// type of image you will encounter.
    /// </summary>
    public class NetpbmImage8 : NetpbmImage<byte>
    {
        public NetpbmImage8(int width, int height, byte highestComponentValue, IEnumerable<Component> components,
            IEnumerable<IEnumerable<byte>> pixelData)
            : base(width, height, highestComponentValue, components, pixelData)
        {
        }

        public override int BytesPerPixelComponent
        {
            get { return 1; }
        }

        public override double ScalePixelComponent(byte pixelComponent)
        {
            return pixelComponent / (double)HighestComponentValue;
        }
    }
}
