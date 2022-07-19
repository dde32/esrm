using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    [DataContract]
    public class TriggerValue
    {
        [DataMember]
        public float Value { get; set; }
        [DataMember]
        public int ResultValue
        {
            get;
            set;
        }

        public TriggerValue(float value, int resultValue)
        {
            Value = value;
            ResultValue = resultValue;
        }

        public TriggerValue()
        {

        }
    }


    [DataContract]
    public class BrakeTriggerValue
    {
        [DataMember]
        public int BrakeForceValue { get; set; }

        [DataMember]
        public float BrakeForceCoef { get; set; }

        [DataMember]
        public int BrakeCycle
        {
            get;
            set;
        }

        [DataMember]
        public int EffectiveBrake
        {
            get;
            set;
        }

        public BrakeTriggerValue(int brakeForce, float value, int brakecycle,int effectiveBrake)
        {
            BrakeForceValue = brakeForce;
            BrakeForceCoef = value;
            BrakeCycle = brakecycle;
            EffectiveBrake = effectiveBrake;
        }

        public BrakeTriggerValue()
        {

        }
    }

    [DataContract]
    public class  BaseThrottleCurve :  IBaseThrottleCurve
    {
        [DataMember]
        public string Title{get;set;}
        [DataMember]
        public List<TriggerValue> Values { get; set; }

        [IgnoreDataMember]
        List<TriggerValue> _initialValues;

        [DataMember]
        public float MinTriggerValue { get; set; } // utilisé également pour calibrer le gamepad
        [DataMember]
        public float MaxTriggerValue { get; set; } // utilisé également pour calibrer le gamepad
        [DataMember]
        public float MinResultValue { get; set; }
        [DataMember]
        public float MaxResultValue { get; set; }


        public  BaseThrottleCurve()
        {
            Values = new List<TriggerValue>();
            _initialValues = new List<TriggerValue>();
        }

        public BaseThrottleCurve(BaseThrottleCurve source) : base()
        {
            MinTriggerValue = source.MinTriggerValue;
            MaxTriggerValue = source.MaxTriggerValue;
            MinResultValue = source.MinResultValue;
            MaxResultValue = source.MaxResultValue;
            Values.AddRange(source.Values);
        }

        public void SmoothCurve(int start, int end, int startValue, int endValue)
        {
            if (MaxResultValue == 0)
                MaxResultValue = 63;

            int intervalls = end - start;
            int delta = endValue - startValue;
            float value = (float)delta / (float)intervalls;

            int idx = 1;
            for (int i = start; i <= end; i++)
            {
                if (i == start)
                    this.Values[i].ResultValue = startValue;
                else if (i == end)
                    this.Values[i].ResultValue = endValue;
                else
                    this.Values[i].ResultValue = (int)((this.Values[start].ResultValue + (int)(idx * value)));

                if (this.Values[i].ResultValue > MaxResultValue)
                    this.Values[i].ResultValue = (int)MaxResultValue;
                if (this.Values[i].ResultValue < MinResultValue)
                    this.Values[i].ResultValue = (int)MinResultValue;

                idx++;
            }
        }


        public void SmoothCurveForBrakes(int start, int end, int startValue, int endValue)
        {
            int intervalls = end - start;
            int delta = endValue - startValue;
            float value = (float)delta / (float)intervalls;

            int idx = 1;
            for (int i = start; i <= end; i++)
            {
                if (i == start)
                    this.Values[i].ResultValue = startValue;
                else if (i == end)
                    this.Values[i].ResultValue = endValue;
                else
                    this.Values[i].ResultValue = (int)((this.Values[start].ResultValue + (int)(idx * value)));

                //if (this.Values[i].ResultValue > MaxResultValue)
                //    this.Values[i].ResultValue = (int)MaxResultValue;
                //if (this.Values[i].ResultValue < MinResultValue)
                //    this.Values[i].ResultValue = (int)MinResultValue;

                idx++;
            }
        }

        public override string ToString()
        {
            return Title;
        }

        public void BeginUpdate()
        {
            if (_initialValues == null)
                _initialValues = new List<TriggerValue>();

            _initialValues.Clear();
            foreach(TriggerValue t in Values)
                _initialValues.Add(new TriggerValue(t.Value,t.ResultValue));
        }
        public void CancelUpdate()
        {
            if (_initialValues != null && _initialValues.Count > 0)
            {
                Values.Clear();
                foreach (TriggerValue t in _initialValues)
                    Values.Add(new TriggerValue(t.Value, t.ResultValue));
            }
        }


        public virtual void InitDefaultValues(bool forBrakes)
        {
            MinTriggerValue = 0;
            MaxTriggerValue = 1;
            if (Values == null)
                Values = new List<TriggerValue>();

            if (!forBrakes)
            {
                MinResultValue = 0;
                MaxResultValue = 63;

                this.Values.Clear();
                for (float i = MinTriggerValue; i <= MaxTriggerValue;)
                {
                    if (i > 0.990)
                        this.Values.Add(new TriggerValue(i, (int)MaxResultValue));
                    else
                        this.Values.Add(new TriggerValue(i, (int)(i * (float)MaxResultValue)));

                    if (this.Values[Values.Count - 1].ResultValue > MaxResultValue)
                        this.Values[Values.Count - 1].ResultValue = (int)MaxResultValue;
                    i += (float)0.01;

                }
            }
            else
            {
                InitDefaultValuesForBraking();
            }
        }


        private  void InitDefaultValuesForBraking()
        {

            MinResultValue = 0;
            MaxResultValue = 1;

            this.Values.Clear();
            this.Values.Add(new TriggerValue((float)0.0, 0));
            this.Values.Add(new TriggerValue((float)0.1, GlobalDatas.BTV_1.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)0.2, GlobalDatas.BTV_2.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)0.3, GlobalDatas.BTV_3.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)0.4, GlobalDatas.BTV_4.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)0.5, GlobalDatas.BTV_5.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)0.6, GlobalDatas.BTV_6.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)0.7, GlobalDatas.BTV_7.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)0.8, GlobalDatas.BTV_8.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)0.9, GlobalDatas.BTV_9.BrakeForceValue));
            this.Values.Add(new TriggerValue((float)1, 10));

            //MinResultValue = 12;
            //MaxResultValue = 0;

            //if (Values == null)
            //    Values = new List<TriggerValue>();

            //this.Values.Clear();
            //for (float i = MinTriggerValue; i <= MaxTriggerValue;)
            //{
            //    if (i > 0.990)
            //        this.Values.Add(new TriggerValue(i, (int)MaxResultValue));
            //    else if( i == 0)
            //        this.Values.Add(new TriggerValue(i, (int)MinResultValue));
            //    else
            //        this.Values.Add(new TriggerValue(i, (int)MinResultValue - (int)(MinResultValue * i)));

            //    //if (this.Values[Values.Count - 1].ResultValue > MinResultValue)
            //    //    this.Values[Values.Count - 1].ResultValue = (int)MinResultValue;
            //    i += (float)0.01;

            //}
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseThrottleCurve)
                return string.IsNullOrEmpty(Title) ? false : Title.Equals((obj as BaseThrottleCurve).Title);
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(Title) ? 0 : Title.GetHashCode();
        }
    }

    [DataContract]
    public class HandsetThrottleCurve : BaseThrottleCurve, IBaseThrottleCurve
    {
        public HandsetThrottleCurve() : base()
        {
            MinTriggerValue = 0;
            MaxTriggerValue = 63;
            MinResultValue = 0;
            MaxResultValue = 63;
        }

        public HandsetThrottleCurve(HandsetThrottleCurve source) : base()
        {
            MinTriggerValue = source.MinTriggerValue;
            MaxTriggerValue = source.MaxTriggerValue;
            MinResultValue = source.MinResultValue;
            MaxResultValue = source.MaxResultValue;

            foreach(TriggerValue t in source.Values)
                Values.Add( new TriggerValue(t.Value,t.ResultValue));
        }

        public override void InitDefaultValues(bool forBrakes)
        {
            if (Values == null)
                Values = new List<TriggerValue>();
            this.Values.Clear();


            for (int i = (int)MinTriggerValue; i <= MaxTriggerValue; i++)
            {
                this.Values.Add(new TriggerValue(i, i));
            }
        }

        public void InitDefaultValues(int start, int end, int startValue, int endValue)
        {
            if (Values == null)
                Values = new List<TriggerValue>();
            this.Values.Clear();

            if (MaxResultValue == 0)
                MaxResultValue = 63;

            int intervalls = end - start;
            int delta = endValue - startValue;
            float value = (float)delta / (float)intervalls;

            int idx = 1;
            for (int i = start; i <= end; i++)
            {
                if (i == start)
                    this.Values.Add(new TriggerValue(i, 0));
                else if (i == end)
                    this.Values.Add(new TriggerValue(i, (int)MaxResultValue));
                else
                    this.Values.Add(new TriggerValue(i, (int)((this.Values[start].ResultValue + (int)(idx * value)))));

                if (this.Values[i].ResultValue > MaxResultValue)
                    this.Values[i].ResultValue = (int)MaxResultValue;
                if (this.Values[i].ResultValue < MinResultValue)
                    this.Values[i].ResultValue = (int)MinResultValue;

                idx++;
            }
        }

    }


    [DataContract]
    public class GamePadThrottleCurve : BaseThrottleCurve, IBaseThrottleCurve
    {
        //[DataMember]
        //public int ContinuousBrakeCount { get; set; } // Pour les freinage, permet de savoir combien de signal Brake on envoit avant un délai

        public GamePadThrottleCurve() : base()
        {
            MinTriggerValue = 0;
            MaxTriggerValue = 1;
            MinResultValue = 0;
            MaxResultValue = 63;
            //ContinuousBrakeCount = 1;
        }

        public GamePadThrottleCurve(int minResultValue, int maxResultValue) : base()
        {
            MinTriggerValue = 0;
            MaxTriggerValue = 1;
            MinResultValue = minResultValue;
            MaxResultValue = maxResultValue;
            //ContinuousBrakeCount = 1;
        }

        public GamePadThrottleCurve(GamePadThrottleCurve source) : base()
        {
            //ContinuousBrakeCount = source.ContinuousBrakeCount >= 1 ? source.ContinuousBrakeCount : 1;
            MinTriggerValue = source.MinTriggerValue;
            MaxTriggerValue = source.MaxTriggerValue;
            MinResultValue = source.MinResultValue;
            MaxResultValue = source.MaxResultValue;
            foreach (TriggerValue t in source.Values)
                Values.Add(new TriggerValue(t.Value, t.ResultValue));
        }
    }




    /*

    public class GamePadBrakeCurve : IBaseThrottleCurve
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public List<TriggerValue> Values { get; set; }

        [IgnoreDataMember]
        List<BrakeTriggerValue> _initialValues;

        [DataMember]
        public float MinTriggerValue { get; set; } // utilisé également pour calibrer le gamepad
        [DataMember]
        public float MaxTriggerValue { get; set; } // utilisé également pour calibrer le gamepad
        [DataMember]
        public float MinResultValue { get; set; }
        [DataMember]
        public float MaxResultValue { get; set; }


        public BaseThrottleCurve()
        {
            Values = new List<TriggerValue>();
            _initialValues = new List<TriggerValue>();
        }

        public BaseThrottleCurve(BaseThrottleCurve source) : base()
        {
            MinTriggerValue = source.MinTriggerValue;
            MaxTriggerValue = source.MaxTriggerValue;
            MinResultValue = source.MinResultValue;
            MaxResultValue = source.MaxResultValue;
            Values.AddRange(source.Values);
        }

        public void SmoothCurve(int start, int end, int startValue, int endValue)
        {
            if (MaxResultValue == 0)
                MaxResultValue = 63;

            int intervalls = end - start;
            int delta = endValue - startValue;
            float value = (float)delta / (float)intervalls;

            int idx = 1;
            for (int i = start; i <= end; i++)
            {
                if (i == start)
                    this.Values[i].ResultValue = startValue;
                else if (i == end)
                    this.Values[i].ResultValue = endValue;
                else
                    this.Values[i].ResultValue = (int)((this.Values[start].ResultValue + (int)(idx * value)));

                if (this.Values[i].ResultValue > MaxResultValue)
                    this.Values[i].ResultValue = (int)MaxResultValue;
                if (this.Values[i].ResultValue < MinResultValue)
                    this.Values[i].ResultValue = (int)MinResultValue;

                idx++;
            }
        }


        public void SmoothCurveForBrakes(int start, int end, int startValue, int endValue)
        {
            int intervalls = end - start;
            int delta = endValue - startValue;
            float value = (float)delta / (float)intervalls;

            int idx = 1;
            for (int i = start; i <= end; i++)
            {
                if (i == start)
                    this.Values[i].ResultValue = startValue;
                else if (i == end)
                    this.Values[i].ResultValue = endValue;
                else
                    this.Values[i].ResultValue = (int)((this.Values[start].ResultValue + (int)(idx * value)));

                if (this.Values[i].ResultValue > MinResultValue)
                    this.Values[i].ResultValue = (int)MinResultValue;
                if (this.Values[i].ResultValue < MaxResultValue)
                    this.Values[i].ResultValue = (int)MaxResultValue;

                idx++;
            }
        }

        public override string ToString()
        {
            return Title;
        }

        public void BeginUpdate()
        {
            if (_initialValues == null)
                _initialValues = new List<TriggerValue>();

            _initialValues.Clear();
            foreach (TriggerValue t in Values)
                _initialValues.Add(new TriggerValue(t.Value, t.ResultValue));
        }
        public void CancelUpdate()
        {
            if (_initialValues != null && _initialValues.Count > 0)
            {
                Values.Clear();
                foreach (TriggerValue t in _initialValues)
                    Values.Add(new TriggerValue(t.Value, t.ResultValue));
            }
        }


        public virtual void InitDefaultValues(bool forBrakes)
        {
            MinTriggerValue = 0;
            MaxTriggerValue = 1;
            if (Values == null)
                Values = new List<TriggerValue>();

            if (!forBrakes)
            {
                MinResultValue = 0;
                MaxResultValue = 63;

                this.Values.Clear();
                for (float i = MinTriggerValue; i <= MaxTriggerValue;)
                {
                    if (i > 0.990)
                        this.Values.Add(new TriggerValue(i, (int)MaxResultValue));
                    else
                        this.Values.Add(new TriggerValue(i, (int)(i * (float)MaxResultValue)));

                    if (this.Values[Values.Count - 1].ResultValue > MaxResultValue)
                        this.Values[Values.Count - 1].ResultValue = (int)MaxResultValue;
                    i += (float)0.01;

                }
            }
            else
            {
                InitDefaultValuesForBraking();
            }
        }


        private void InitDefaultValuesForBraking()
        {
            MinResultValue = 12;
            MaxResultValue = 0;

            if (Values == null)
                Values = new List<TriggerValue>();

            this.Values.Clear();
            for (float i = MinTriggerValue; i <= MaxTriggerValue;)
            {
                if (i > 0.990)
                    this.Values.Add(new TriggerValue(i, (int)MaxResultValue));
                else if (i == 0)
                    this.Values.Add(new TriggerValue(i, (int)MinResultValue));
                else
                    this.Values.Add(new TriggerValue(i, (int)MinResultValue - (int)(MinResultValue * i)));

                //if (this.Values[Values.Count - 1].ResultValue > MinResultValue)
                //    this.Values[Values.Count - 1].ResultValue = (int)MinResultValue;
                i += (float)0.01;

            }
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseThrottleCurve)
                return string.IsNullOrEmpty(Title) ? false : Title.Equals((obj as BaseThrottleCurve).Title);
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(Title) ? 0 : Title.GetHashCode();
        }
    }
    */
}
