Q1  Overloading, Overriding, and Binding 
    a)  What is the difference between Method Overloading and Method Overriding? 
            method overloading -> same name method but difference parameter in same class
            method overriding  -> same method and same parametar but in child class 
    b)  What is the difference between static and dynamic binding?
            Static binding => The compiler determines that it will handle the refs if they are different. 
            Dynamic binding => It determines which refs will be called in the runtime.
Q2  Sealed Classes and Methods 
    a)  What is the purpose of the sealed keyword when applied to a class? 
            It prevents inheritance for that class.
    b)  What is the difference between a sealed class and a sealed method? 
            A sealed class cannot be inherited. 
            A sealed function does not inherit, but it does not prevent a sealed class from inheriting.
    c)  Can a sealed method be overridden? Why?
            No. A sealed method prevents overriding.