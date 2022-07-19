namespace ESRM.Entities
{
    public interface IBaseThrottleCurve
    {
        float MaxResultValue { get; set; }
        float MaxTriggerValue { get; set; }
        float MinResultValue { get; set; }
        float MinTriggerValue { get; set; }
        string Title { get; set; }

        void InitDefaultValues(bool forBrakes);
        void SmoothCurve(int start, int end,int startValue,int endValue);
    }
}