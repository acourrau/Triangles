# Cherwell Triangle Coding Challenge

There are 2 URL patterns to hit:

/Triangle/id

and 

/Triangle/x1/y1/x2/y2/x3/y3

Both should return an object with the following data:

 - Name: The name of the triangle, e.g. `"name":"A1"`
 - Points: An array of 3 points for the 3 verticies of the triangle, e.g. `"points":[{"x":0,"y":0},{"x":0,"y":10},{"x":10,"y":10}]`
 
Full JSON example output: `{"name":"A1","points":[{"x":0,"y":0},{"x":0,"y":10},{"x":10,"y":10}]}`

The application should validate the input.
 - /Triangle/id accepts values A1-F12 as shown in the coding challenge PDF.
 - /Triangle/x1/y1/x2/y2/x3/y3 accepts 6 integers as x-y coordinates such that x1 and y1 create one corner of the triangle
 
If invalid input is entered, a list of errors will be returned with a simple description of the specific problem(s) encountered.

