using System;
using System.IO;
using System.Drawing;

namespace VehicleTracking_Data_Entities
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

        public string StringifiedImage
        {
            get
            {
                return Convert.ToBase64String(ImageData);
            }
        }

        internal static ImageElement InstanceForTestingPurposes()
        {
            return new ImageElement();
        }

        protected ImageElement() { }

        public static ImageElement FromImageData(string
            imageDataToSet)
        {
            return new ImageElement(imageDataToSet);
        }

        protected ImageElement(string imageDataToSet)
        {
            try
            {
                ImageData = Convert.FromBase64String(imageDataToSet);
            }
            catch (SystemException)
            {
                throw new VehicleTrackingException(
                    ErrorMessages.StringIsNotInBase64Format);
            }
        }
    }
}