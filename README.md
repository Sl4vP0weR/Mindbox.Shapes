<p><strong>Задание:</strong></p>

<p>Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:</p>

<ul>
	<li>
	<p>Юнит-тесты</p>
	</li>
	<li>
	<p>Легкость добавления других фигур</p>
	</li>
	<li>
	<p>Вычисление площади фигуры без знания типа фигуры в compile-time</p>
	</li>
	<li>
	<p>Проверку на то, является ли треугольник прямоугольным</p>
	</li>
</ul>

<p><strong>Task:</strong></p>

<p>Write a C# library for distribution to external clients, capable of calculating the area of a circle based on its radius and the area of a triangle based on its three edges. In addition to functionality, we will value:</p>

<ul>
  <li>
    <p>Unit tests</p>
  </li>
  <li>
    <p>Ease of adding other shapes</p>
  </li>
  <li>
    <p>Calculating the area of a shape without knowing the type of the shape at compile-time</p>
  </li>
  <li>
    <p>Checking whether a triangle is rectangular</p>
  </li>
</ul>

<p>Thanks to Mindbox for this cool task.</p>
I wanted to make it as good as possible and overengineered it in the end.<br/>
Reference values for expected test results were compared to results at <a href="https://www.omnicalculator.com/">OmniCalculator.com</a>.<br/>
Any new shape can be created with this code-base, e.g. Tetragon and Rectangle implementation took only ~3-4 minutes.<br/>
Project can be extended with 3D shapes.<br/>
Unit-tests coverage is close to 100%.<br/>
There's a shape calculation API used as an example of external usage.<br/>

Inhertitance and interfaces implementation establish abstraction layers.
```csharp
IShape2D shape = Triangle.Regular(1);
shape.Area // 0.43301270189221902
if(shape is IEdges IEdges)
    polygon.Edges // [1, 1, 1]
```
It's recommended to use interfaces whenever possible.

Usage (See tests for more examples):

- Circle
```csharp
var circle = Circle.WithRadius(4);
shape.Perimeter // 25.132741228718345
shape.Area // 50.26548245743669

shape = Circle.WithArea(cirlce.Area);
shape.Radius // 4

shape = Circle.WithPerimeter(cirlce.Perimeter);
shape.Radius // 4
```
- Triangle
```csharp
var shape = Triangle.WithEdges(2, 3, 4);
shape.Perimeter // 9
shape.Area // 2.904737509655562
shape.Is(PolygonType.Scalene) // true

shape = Triangle.WithEdges(3, 4, 5);
shape.Is(TriangleType.Rectangular) // true
```
- Tetragon
```csharp
var shape = Tetragon.WithVertices((0, 0), (1, 2), (2, 0), (1, -2)); // rhombus
shape.Area // 4
shape.Perimeter // 8.9442719099991592
```
- Rectangle
```csharp
var shape = Rectangle.WithEdges(1); // 1x1 square
shape.Perimeter // 4
shape.Area // 1
shape.Is(PolygonType.Equilateral) // true

shape = Rectangle.WithEdges(1, 2); // 1x2 rectangle
shape.Area // 2
```
- Polygon
```csharp
var shape = Polygon.Regular(5); // pentagon with each side equal to 1
shape.Area // 1.720477400588968
shape.Perimeter // 5
```