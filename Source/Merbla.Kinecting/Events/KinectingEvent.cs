namespace Merbla.Kinecting.Events
{
    public class KinectingEvent<T>
    {
        public KinectingEvent(T messageObject)
        {
            MessageObject = messageObject;
        }

        public T MessageObject { get; set; }
    }
}