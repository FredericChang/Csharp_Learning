namespace TwoInterface
{
    public class Box : IEnglishDimensions, IMetricDimensions
    {
        float lengthInches;
        float widthInches;
        public float Length { get; }
        public float Width { get; }

        public Box(float lengthInches, float widthInches)
        {
            this.lengthInches = lengthInches;
            this.widthInches = widthInches;
        }

        float IEnglishDimensions.Length => lengthInches;
        float IEnglishDimensions.Width => widthInches;

        float IMetricDimensions.Length => lengthInches * 2.54f;
        float IMetricDimensions.Width => widthInches * 2.54f;

    }
}