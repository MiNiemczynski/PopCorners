<h2>Description</h2>
<p>
  PopCorners is a movie service application that allows for <strong>CRUD</strong> operations, result filtering in the business logic layer, and tabs system. The application follows the <strong>MVVM</strong> (Model-View-ViewModel) design pattern.
</p>

<p>
  The project consists of:
</p>
<ul>
  <li><strong>XAML Views</strong> – Responsible for the user interface. They display data and collect user input from forms.</li>
  <li><strong>ViewModels</strong> – Communicates view with business logic. They manage data using <strong>data binding</strong> and implement commands and interaction logic.</li>
  <li><strong>Services</strong> – Is using <strong>Entity Framework Core</strong> to communicate with the database. They handle data downloading, saving, updating and soft deleting.</li>
</ul>

<h2>Technologies</h2>
<ul>
  <li>.NET</li>
  <li>XAML</li>
  <li>Entity Framework Core</li>
</ul>

<h2>DTO</h2>
<p>
  The application operates on 16 database tables, so to improve performance and simplify data transfer between layers, the <strong>DTO</strong> (Data Transfer Object) pattern has been implemented.
</p>

<h2>License</h2>
<p>
  This project is licensed under the <strong>MIT</strong> License.
</p>
