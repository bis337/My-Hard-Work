namespace ModelPerson
{
    /// <summary>
    /// Представляет список персон. 
    /// Наследуется от <see cref="List{Person}"/>.
    /// </summary>
    public class PersonList : List<Person>
    {
        /// <summary>
        /// Создает новый экземпляр класса PersonList с указанным именем.
        /// </summary>
        /// <param name="listName">Имя списка.</param>
        public PersonList()
        {}

        /// <summary>
        /// Проверяет, что индекс находится в допустимых пределах.
        /// </summary>
        /// <param name="index">Индекс для проверки.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если индекс вне диапазона.</exception>
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index), "Индекс вне диапазона.");
            }
        }

        /// <summary>
        /// Добавляет персону в список по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс, 
        /// по которому нужно добавить персону.</param>
        /// <param name="person">Персона для добавления.</param>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, 
        /// если индекс вне диапазона.</exception>
        public void AddPersonAt(int index, Person person)
        {
            ValidateIndex(index);
            Insert(index, person);
            
        }

        /// <summary>
        /// Добавляет персону в конец списка.
        /// </summary>
        /// <param name="person">Персона для добавления.</param>
        public void AddPerson(Person person)
        {
            Add(person);
        }

        /// <summary>
        /// Удаляет персону из списка.
        /// </summary>
        /// <param name="person">Персона для удаления.</param>
        public void RemovePerson(Person person)
        {
            Remove(person);
        }

        /// <summary>
        /// Удаляет персону из списка по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс персоны для удаления.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если индекс вне диапазона.</exception>
        public void RemovePersonAt(int index)
        {
            ValidateIndex(index);
            RemoveAt(index);
        }

        /// <summary>
        /// Возвращает персону по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс персоны.</param>
        /// <returns>Персона по указанному индексу.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если индекс вне диапазона.</exception>
        public Person GetPersonAt(int index)
        {
            ValidateIndex(index);
            return this[index];
        }

        /// <summary>
        /// Возвращает индекс указанной персоны в списке.
        /// </summary>
        /// <param name="person">Персона, индекс которой нужно найти.</param>
        /// <returns>Индекс персоны в списке, или -1, 
        /// если персона не найдена.</returns>
        public int GetIndexOf(Person person)
        {
            return IndexOf(person);
        }

        /// <summary>
        /// Очищает список персон.
        /// </summary>
        public void ClearList()
        {
            Clear();
        }

        /// <summary>
        /// Возвращает количество персон в списке.
        /// </summary>
        /// <returns>Количество персон в списке.</returns>
        public new int Count
        {
            get { return base.Count; }
        }
    }
}
