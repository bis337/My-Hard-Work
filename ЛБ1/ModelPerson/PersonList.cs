using System;
using System.Collections;
using System.Collections.Generic;

namespace ModelPerson
{
    /// <summary>
    /// Представляет список персон.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Хранилище для объектов типа <see cref="Person"/>.
        /// </summary>
        private List<Person> _persons = new List<Person>();

        /// <summary>
        /// Создает новый экземпляр класса PersonList с указанным именем.
        /// </summary>
        public PersonList()
        { }

        /// <summary>
        /// Проверяет, что индекс находится в допустимых пределах.
        /// </summary>
        /// <param name="index">Индекс для проверки.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если индекс вне диапазона.</exception>
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _persons.Count)
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
            _persons.Insert(index, person);
        }

        /// <summary>
        /// Добавляет персону в конец списка.
        /// </summary>
        /// <param name="person">Персона для добавления.</param>
        public void AddPerson(Person person)
        {
            _persons.Add(person);
        }

        /// <summary>
        /// Удаляет персону из списка.
        /// </summary>
        /// <param name="person">Персона для удаления.</param>
        public void RemovePerson(Person person)
        {
            _persons.Remove(person);
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
            _persons.RemoveAt(index);
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
            return _persons[index];
        }

        /// <summary>
        /// Возвращает индекс указанной персоны в списке.
        /// </summary>
        /// <param name="person">Персона, индекс которой нужно найти.</param>
        /// <returns>Индекс персоны в списке, или -1,
        /// если персона не найдена.</returns>
        public int GetIndexOf(Person person)
        {
            return _persons.IndexOf(person);
        }

        /// <summary>
        /// Очищает список персон.
        /// </summary>
        public void ClearList()
        {
            _persons.Clear();
        }

        /// <summary>
        /// Возвращает количество персон в списке.
        /// </summary>
        /// <returns>Количество персон в списке.</returns>
        public int Count
        {
            get { return _persons.Count; }
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий итерацию в коллекции PersonList.
        /// Используется для foreach.
        /// </summary>
        /// <returns>Перечислитель для коллекции PersonList.</returns>
        public IEnumerator<Person> GetEnumerator()
        {
            return _persons.GetEnumerator();
        }

        /// <summary>
        /// Позволяет обращаться к элементам списка по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <returns>Элемент списка по указанному индексу.</returns>
        public Person this[int index] => GetPersonAt(index);
    }
}