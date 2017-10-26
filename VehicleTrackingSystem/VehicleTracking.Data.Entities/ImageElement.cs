using System;
using System.IO;
using System.Drawing;

namespace Domain
{
    public class ImageElement
    {
        public int Id { get; set; }

        private byte[] imageData;
        public virtual byte[] ImageData
        {
            get { return imageData; }
            set
            {
                try
                {
                    AttemptToSetData(value);
                }
                catch (ArgumentException)
                {
                    throw new VehicleTrackingException(
                        ErrorMessages.BinaryInformationIsNotAnImage);
                }
            }
        }

        private void AttemptToSetData(byte[] value)
        {
            using (var memoryStream = new MemoryStream(value))
            {
                Image.FromStream(memoryStream);
                imageData = value;
            }
        }

        internal static ImageElement InstanceForTestingPurposes()
        {
            return new ImageElement();
        }

        protected ImageElement() { }
    }
}