(Lokala ev. redan inst'llda:
dotnet tool install --global dotnet-ef
)

1. dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
2. dotnet add package Microsoft.EntityFrameworkCore.Design

3. La till:
   builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql("Host=localhost;Database=ecommerce_database;Username=myuser;Password=mypassword;"));
   \*välj rätt namn på den databasen du skapat : localhost;<namn på databasen>
   skriv in
   docker image pull Postgres
   docker run --name my-postgres -e POSTGRES_PASSWORD=password -p 5432:5432 d-postgres
   docker exec -it my-postgres bash
   psql -U postgres
   \l
   visar databas:
   \c <namn på databasen du vill gå in på>
   \dt
   kolla alla tabeller.

4. Ny mapp: Database med fil: ApplicationContext

5. Skapade User model

6. psql -U postgres

7.CREATE DATABASE ecommerce_database;

8.Anslut till databas:\c <db namn>

9. dotnet add package Microsoft.AspNetCore.Identity

   10.dotnet ef migrations add InitialCreate

TODO:
User Authentication:

- User registration
- User login/logout
- Password reset functionality

Product Management:

- Add, edit, delete products
- Product categories and subcategories
- Product search and filtering
- Product sorting

Shopping Cart:

- Add/remove items to/from cart
- Update quantity
- Calculate subtotal, taxes, and total
- Save cart for later

Checkout Process:
\*Shipping address

- Billing address
- Payment methods (credit card, PayPal, etc.)
- Order summary
- Order confirmation

Order Management:

- View order history
- Track order status
- Order cancellation
- Order details

User Profile:

- View/edit profile information
- Change password
- View order history

Admin Panel:

- Dashboard with key metrics
- Manage products, categories, and orders
- User management (if applicable)
- Reporting (sales, inventory, etc.)

Security:

- Secure authentication and authorization
- HTTPS for secure data transmission
- Protection against common security threats (SQL injection, XSS, CSRF, etc.)

SEO Optimization:

- SEO-friendly URLs
- Metadata (title tags, meta descriptions)

Responsive Design:

- Ensure the website is mobile-friendly and works well on various devices and screen sizes.

Email Notifications:

- Send confirmation emails for registration, orders, etc.

Localization and Internationalization:

- Support for multiple languages and currencies if needed.

Accessibility:

- Ensure the website is accessible to users with disabilities according to WCAG guidelines.

Legal Compliance:

- Terms and conditions
- Privacy policy
- GDPR compliance (if applicable)

Feedback and Support:

- Contact form
- FAQ page
- Live chat or support ticket system
  Analytics Integration:

Social Media Integration:

- Share buttons

Next: Planera utifran boken 9.3 & generellt hur ska sidan fungera/se ut

Controllers/
HomeController.cs
PostController.cs
CommentController.cs
Models/
User.cs
Post.cs
Comment.cs
Image.cs
Views/
HomeView.html
LogInView.html
CategoryView.html
ProductView.html
CartView.html

users -> logga in/skapa konto -> välj kategori -> välj produkt -> lägg till i kundvagn -> betala/slutför.
-> välj kategori -> välj produkt -> lägg till i kundvagn -> logga in/skapa konto -> betala/slutför.

Controllers/
AccountController.cs // Hanterar inloggning och registrering
ProductController.cs // Hanterar produktsidor och produktrelaterad logik
CartController.cs // Hanterar kundvagnsåtgärder
CheckoutController.cs // Hanterar kassasidan och beställningsprocessen
CategoryController.cs // Hanterar kategorisidor och kategori-relaterad logik
HomeController.cs // Hanterar startsidan och andra generella sidor

Models/
User.cs // Representerar användare i systemet
Product.cs // Representerar produkter som säljs
CartItem.cs // Representerar objekt i kundvagnen
Order.cs // Representerar en beställning
Category.cs // Representerar produktkategorier

Views/
Account/
Login.cshtml // Inloggningsvy
Register.cshtml // Registreringsvy

    Product/
    Product.cshtml // Lista över produkter
    Detail.cshtml // Detaljerad vy för en enskild produkt

    Cart/
    Cart.cshtml // Kundvagnens vy

    Checkout/
    Checkout.cshtml // Kassasidan

    Category/
    Category.cshtml // Lista över produkter i en kategori

    Home/
    Home.cshtml // Startsida
    Privacy.cshtml //

Shared/
\_Layout.cshtml // Gemensam layout för webbplatsen
\_PartialView.cshtml // Delvyer som används på flera sidor, t.ex. navigationsfält
