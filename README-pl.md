<h2>Opis</h2>
<p>
  PopCorners to aplikacja serwisu filmowego umożliwiająca wykonywanie operacji <strong>CRUD</strong>, filtrowanie wyników w warstwie logiki biznesowej oraz systemem zakładek. Aplikacja korzysta z wzorca <strong>MVVM</strong> (Model-View-ViewModel).
</p>

<p>
  Projekt składa się z:
</p>
<ul>
  <li><strong>Widoków XAML</strong> - Odpowiadają za interfejs użytkownika. Prezentują dane oraz zbierają dane wprowadzone przez użytkownika.</li>
  <li><strong>ViewModel</strong> – Pośredniczy między widokami a logiką biznesową. Obsługuje dane za pomocą <strong>data bindingu</strong> oraz implementuje komendy i logikę interakcji.</li>
  <li><strong>Serwisy</strong> – Komunikują się z bazą danych przy użyciu <strong>Entity Framework Core</strong>. Odpowiadają za pobieranie, zapisywanie i aktualizację danych.</li>
</ul>

<h2>Technologie</h2>
<ul>
  <li>.NET</li>
  <li>XAML</li>
  <li>Entity Framework Core</li>
</ul>

<h2>DTO</h2>
<p>
  Aplikacja operuje na 16 tabelach bazy danych, dlatego w celu zwiększenia wydajności i uproszczenia transferu danych między warstwami zastosowano wzorzec <strong>DTO</strong> (Data Transfer Object). 
</p>

<h2>Licencja</h2>
<p>
  Ten projekt jest udostępniony na licencji <strong>MIT</strong>.
</p>
