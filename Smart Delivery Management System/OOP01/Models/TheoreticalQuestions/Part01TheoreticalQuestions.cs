/*


Q1  Object Copying 
        a) What happens when you assign one object variable to another object variable? 
                Both objects end up pointing to the same address in memory
        b) Does assigning one object to another create a new object? Explain. 
                No
                Both objects point to the same place in memory.
        c) What is the difference between copying an object and copying its reference? 
                There's no difference.

Q2  Shallow Copy vs Deep Copy 
    a) What is a Shallow Copy? 
            Copying the elements from the first object to the second object using the values directly in it.
            If it's a value type, it copies the values.
            If it's a reference type, it copies the address.
    b) What is a Deep Copy? 
            Copying all the values and not copying any addresses, all are values
    c) What happens to reference-type members when a Shallow Copy is created? 
            The addresses they point to are copied
    d) What happens to reference-type members when a Deep Copy is created? 
            The values are copied into a new reference type
    e) Give one situation where Deep Copy would be safer than Shallow Copy. 
            For example, if I have an Address class and a Person class and I take an object from Address.
            If I do a deep copy and change the address, it won't change in the original object.
            But if I do a shallow copy and change the address, it will affect both, and in that case, I might not want to change the other one.

Q3  Static Members 
        a) What is a static field, and how is it different from an instance field? 
            A static field is fixed at the class level.
            An instance field belongs only to the object.
        b) What is a static method? Can a static method directly access instance members? 
            The static method is called at the class level,  
            and it cannot access the object's members.
        c) What is a static constructor, and when is it executed?
            It's a special type of constructor.  
            It gets executed when I have a static field and I want to assign it primitive values.
        d) What is a static class? Can you create an object from a static class? 
            It is a class that contains static methods and does not have any regular methods or fields.  
            You cannot create an object from it.
Q4  Extension Methods 
        a) What is an Extension Method? 
            It's a way of making a function that is not inside the class but is called through the class.
        b) What keyword must be used in the first parameter of an extension method? 
            this
        c) Where must an extension method be declared? 
            in the first parameter
        d) Can an extension method access private members of the class it extends? 
            No

Q5  Partial Classes and Partial Methods 
        a) What is a Partial Class? 
            It's one of the ways of writing classes that allows the programmer to split the class across more than one file.
        b) Why would a developer split one class into multiple files? 
            Maybe if another developer is going to work with him on the same class,
            or because if something is done automatically and I’m not afraid to continue on it, an update might delete what I wrote
        c) What is a Partial Method? 
            If I want to make a partial method in another file and I haven't compiled the two files together yet,  
            I tell the compiler that there's another method in the other file.
        d) What happens if a declared partial method has no implementation?
            Nothing happens
*/
