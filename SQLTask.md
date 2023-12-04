<p><strong>Задание:</strong></p>
<p>В базе данных MS SQL Server есть продукты и категории.</p>
<ul>
    <li>
        <p>Одному продукту может соответствовать много категорий.</p></li>
    <li>
        <p>В одной категории может быть много продуктов.</p>
    </li>
</ul>
<p>Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории».</p>
<p>Если у продукта нет категорий, то его имя все равно должно выводиться.</p>

<p><strong>Task:</strong></p>
<p>In MS SQL Server database there are products and categories.</p>
<ul>
    <li>
        <p>One product can correspond to many categories.</p></li>
    <li>
        <p>One category can have many products.</p>
    </li>
</ul>
<p>Write a SQL query to select all "Product Name - Category Name" pairs.</p>
<p>If a product has no categories, its name should still be displayed.</p>

<p><strong>Solution:</strong></p>

```SQL
SELECT products.name AS 'Product Name', categories.name AS 'Category Name'
FROM products
LEFT JOIN product_categories ON products.id = product_categories.product_id
LEFT JOIN categories ON product_categories.category_id = categories.id;
```