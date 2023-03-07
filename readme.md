# .NET Developer Practicum - Refactoring

**Introduction:**

The .Net Developer Practicum is an exercise to extend the functionality of an existing solution.

**The .NET Developer practicum is evaluated on:**

1. Object Oriented Design
2. Readability
3. Maintainability
4. Testability
5. Extensibility

**Hints:**

- Take the time to walk through the existing functionality before trying to make changes
- Feel free to add 3rd party packages as needed

**Technical Requirements:**

Solution must:
- Compile without errors
- Run from the command line
- Pass all automated test cases
- Demonstrate your knowledge of automated testing by implementing both unit and acceptance tests

**Functional Requirements:**

1. Add ability to switch between morning and evening and have that be the first required parameter (case insensitive)
2. Add ability to have different dishes in the morning and at night (See sample input/output below)
3. You can have multiple orders of coffee in the morning (but still no more than 1 each of the other Dish Types)
4. Dessert is not available as a morning Dish Type
5. Preserve existing requirements:
    - You must enter a comma delimited list of Dish Types with at least one selection
    - The output must print Dish Names in the following order: entrée, side, drink, dessert
    - If invalid selection is encountered, then print &quot;error&quot;
    - Ignore whitespace in the input
    - Each Dish Type is optional (i.e. can have zero if not entered in the input)
    - You can have multiple orders of potatoes (but still no more than 1 each of the other Dish Types)
    - If more than one Dish Type is entered, output it once, followed by &quot;(xN)&quot;, e.g. &quot;potato(x2)&quot;

**Dishes for Morning**

| **Dish Type** | **Dish Name** |
| --- | --- |
| 1 (entrée) | egg |
| 2 (side) | toast |
| 3 (drink) | coffee |

**Dishes for Evening**

| **Dish Type** | **Dish Name** |
| --- | --- |
| 1 (entrée) | steak |
| 2 (side) | potato |
| 3 (drink) | wine |
| 4 (dessert) | cake |

**Sample Input and Output:**

| **Input** | **Output** |
| --- | --- |
| morning, 1, 2, 3 | egg,toast,coffee |
| Morning,3,3,3 | coffee(x3) |
| morning ,1,3,2,3 | egg,toast,coffee(x2) |
| morning, 1, 2, 2 | error |
| morning, 1, 2, 4 | error |
| evening,1, 2, 3, 4 | steak,potato,wine,cake |
| Evening,1, 2, 2, 4 | steak,potato(x2),cake |
| evening,1, 2, 3, 5 | error |
| evening,1, 3, 2, 3 | error |


## Developer Solution - How to use it 

It can be accessed by ConsoleApp or REST API

1. For ConsoleApp:

    1.1. Run ConsoleApp project
    ```.NET CLI
    dotnet run --project GrosvenorDeveloperPracticum 
    ````
    1.2. Type an order and press **Enter** 
    ```.NET CLI
    morning, 1, 2, 3
    ````

2. For REST API: 

	2.1. Pre-requisite: It's necessary .NET 7 to run REST API and integration tests.
	
	2.2. Run API project.
    ```.NET CLI
    dotnet run --project API 
    ````
    2.3. For more information about using the API, see Swagger (http://localhost:5271/swagger/) or find the postman collection on root directory.
    
    2.4. Post an order.
    
    ```cURL
    curl --location 'http://localhost:5271/order' \
    --header 'Content-Type: application/json' \
    --data '{
      "menu": "morning",
      "dishes": [1,2,3]
    }'
    ````

