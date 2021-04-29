using MediatR;

namespace FirebaseSender.BL.Contracts.Commands
{
    /// <summary>
    /// Dto для создания push-уведомления
    /// </summary>
    public class SendMessageCommand : IRequest<bool>
    {
        /// <summary>
        /// заголовок сообщения
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// список номеров телефонов (один или несколько) пользователей, для которых отправляется сообщение
        /// </summary>
        public string[] Phones { get; set; }
    }
}
