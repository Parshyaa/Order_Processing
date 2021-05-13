# Order_Processing

# For Running the project, Please follow the steps given below,
1. The solution is created in VS2019 with .NET Core 3.1 
2. After the project is open in VS 2019, do run the project to see if its compiling properly
3. Run the project. the defualt base URL is http://localhost:8082/api/

# To Execute the functinos please follow the below URL
1. http://localhost:8082/api/getAll - Will return list of all the orders
2. http://localhost:8082/api/{id} - will retrun the specific order of the id specified.
3. http://localhost:8082/api/create - this will create the orders with the ordersDetails passed
  please post this using the following json string while testing the above create orders.
    [{
        "productId":2,
        "quantity":2
    },{
        "productId":1,
        "quantity":2
    },{
        "productId":5,
        "quantity":3
    }]
    the above function will return the new order with the details items and the minimumbox size.
   
 
 Assumption, the list of product type given 
 1- photoBook
2- calendar 
3- canvas 
4- set of greetings card.
5- mug — 94 
