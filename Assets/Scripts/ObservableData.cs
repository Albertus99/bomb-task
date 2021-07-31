using System;

public class ObserveDataToken<TType>
{
    private readonly Action<TType> set;

    public ObserveDataToken(Action<TType> set)
    {
        this.set = set;
    }

    public void Set(TType data)
    {
        set?.Invoke(data);
    }
}

public class ObservableData<TType> where TType : IEquatable<TType>
{
    public delegate void OnChangeHandler(TType data);

    private TType data;
       
    private OnChangeHandler singleSubscriptions;
    private OnChangeHandler permanentSubscriptions;

    public ObservableData(out ObserveDataToken<TType> token)
    {
        token = new ObserveDataToken<TType>(SetData);
    }

    void SetData(TType newData)
    {
        Value = newData;
    }
    public TType Value
    {
        get => data;
        private set
        {
            if (!value.Equals(data))
            {
                data = value;
                singleSubscriptions?.Invoke(value);
                permanentSubscriptions?.Invoke(value);
                singleSubscriptions = null;
            }
        }
    }

    public void SingleSubscribe(OnChangeHandler call)
    {
        singleSubscriptions += call;
    }
        
    public void PermanentSubscribe(OnChangeHandler call)
    {
        permanentSubscriptions += call;
    }
        
    public void RemoveSingleSubscription(OnChangeHandler call)
    {
        singleSubscriptions -= call;
    }
        
    public void RemovePermanentSubscription(OnChangeHandler call)
    {
        permanentSubscriptions -= call;
    }
}