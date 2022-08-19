# Performance analysis of different container types vs primitives
As part of my Software Craftsmanship training I have been introduced to the [Object Calisthenics](https://bolcom.github.io/student-dojo/legacy-code/DevelopersAnonymous-ObjectCalisthenics.pdf), rule 3 of which is "Wrap all primitives and Strings", which I understand the purpose of but it immediately sends off red flags, what about the overhead?! Think about the performance impact! 
So to ease my woes and sate my curiosity, I created a small Test that compared the performance of using and comparing different types, the results are as follows:

|               | Equal | Not Equal | Equal Mutation |
|---------------|-------|-----------|----------------|
| Primitive     | 7ms   | 6ms       | 7ms            |
| Class         | 42ms  | 30ms      | 22ms           |
| Struct        | 142ms | 132ms     | 133ms          |
| Record Class  | 71ms  | 59ms      | 37ms           |
| Record Struct | 15ms  | 14ms      | 15ms           |

There are nuances to using different container types, primarily:
1. Reference vs Value types
2. Equality comparisons
3. Mutability

But as long as those are understood, it would appear to me that the use of Record Structs as primitive wrappers is acceptable in all but the most performant intensive workloads.