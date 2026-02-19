using System;
using System.Collections.Generic;

namespace ModelPerson
{
    /// <summary>
    /// Внутренний класс для передачи данных обработчикам свойств.
    /// </summary>
    public class PropertyHandlerDTO 
    {
        /// <summary>
        /// Название свойства.
        /// </summary>
        public string PropertyName { get; } 

        /// <summary>
        /// Типы исключений, которые обрабатываются.
        /// </summary>
        public List<Type> ExceptionTypes { get; } 

        /// <summary>
        /// Действие, выполняемое для обработки свойства.
        /// </summary>
        public Action PropertyHandlingAction { get; } 

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PropertyHandlerDTO"/>.
        /// </summary>
        /// <param name="propertyName">Название свойства.</param>
        /// <param name="exceptionTypes">Типы исключений.</param>
        /// <param name="propertyHandlingAction">Действие для обработки свойства.</param>
        /// //TODO: RSDN
           public PropertyHandlerDTO(string propertyName, List<Type> exceptionTypes, Action propertyHandlingAction) 
        {
            PropertyName = propertyName;
            ExceptionTypes = exceptionTypes;
            PropertyHandlingAction = propertyHandlingAction;
        }
    }
}