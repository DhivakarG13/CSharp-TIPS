### Detailing your approach and any assumptions you made. 

### Understandings : 
- A Linq query always returns a list of type IEnumberable<Anonymous Type>.

### Task 1 :
#### New Queries Used:
- Where : Gets a predicate and selects the items in the list that returns true for the predicate.
- Select : Used to create a new list where the elements or fields of objects can be picked.
- OrderByDescending : Gets one of the field in the object and sorts the list with respect to that field.

### Task 2 :
#### New Queries Used:
- GroupBy : Gets a func which takes a object returns the field of the object, the list is grouped into several sub lists with objects of same type.
- Join : used to join two lists that meets a condition
   * Gets the list to join with new list.
   * Gets the fields from both list to compare.
   * we can select the fields from both the lists to add to the new List.

### Task 3 :
#### New Queries Used:
- Distinct : Returns a list with no repeated elements.
- SelectMany : Used in List of lists , returns a List of desired or selected elements.
  - If Select is used the result will be list of list too.
- OrderBy : Gets the field of object and orders the list according to the field in ascending order.

### Task 4 :
#### Understandings:
- For each linq query the whole list will be enumerated.
- So having the queries that returns a list with less count, which makes the enumerations / iteration of next queries less will be a best practice.

### Task 5 :
#### Understandings:
- Using fluent APIs to create class query builder enables us to chain the queries together.
- Each methods returns the current instance of the class (this) therefore other methods can be called.
- The Execute() method returns the list of type object.
- Using dynamic Key so the type of variable is varied multiple times during runtime and the element of the
anonymous object which is actually made of different known types can be accessed.