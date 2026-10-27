# Assignment 02 - Theoretical Questions

## Question 1
### a) What is the difference between a class and a struct?
**Answer:**
* A class is stored in the heap, so I'll use it when I want the object to have a longer lifetime or if it’s big in size, but accessing it will take a bit longer because it’s stored randomly in the heap.
* A struct is stored in the stack, so I can access it faster, but it shouldn’t be too big because the stack space is small.

---

### b) Why are classes more suitable than structs for large applications?
**Answer:**
* Because they allow me to do inheritance, which is closer to real life.

---

## Question 2
### Consider the following code:

```csharp
public class Shipment
{
    public string TrackingCode { get; set; }
}

public class ExpressShipment : Shipment
{
    public decimal ExtraFee { get; set; }
}
```

## Question 2
### a) Which class is the parent class?
**Answer:**
* Shipment

---

### b) Which class is the subclass?
**Answer:**
* ExpressShipment

---

### c) What members are inherited by ExpressShipment?
**Answer:**
* Tracking Code

---

### d) Why is inheritance better than copying the same code into multiple classes?
**Answer:**
* Because if I want to make a change:
* If I copied the code, I’d have to change it in all places.
* If I used inheritance, I’d only need to change it once.
* Also, copying takes more time and the code would be longer, whereas with inheritance the code is shorter and quicker to write.

---