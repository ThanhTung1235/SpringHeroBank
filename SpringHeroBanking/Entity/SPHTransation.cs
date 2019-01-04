namespace SpringHeroBanking.Entity
{
    public class SPHTransation
    {
        public enum TransactionType
        {
            DEPOSIT = 1,
            WITHDRAW = 2,
            TRANSFER = 3
        }

        public enum ActiveStatus
        {
            PROCESSING = 1,
            DONE = 2,
            LOCKED = 3,
            DELETED = 4
        }

        private string _id;
        private decimal _amount;
        private string _content;
        private string _senderAccountNumber;
        private string _recevierAccountNumber;
        private TransactionType _type;
        private string _createAt;
        private ActiveStatus _status;


        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public decimal Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public string Content
        {
            get => _content;
            set => _content = value;
        }

        public string SenderAccountNumber
        {
            get => _senderAccountNumber;
            set => _senderAccountNumber = value;
        }

        public string RecevierAccountNumber
        {
            get => _recevierAccountNumber;
            set => _recevierAccountNumber = value;
        }

        public TransactionType Type
        {
            get => _type;
            set => _type = value;
        }

        public string CreateAt
        {
            get => _createAt;
            set => _createAt = value;
        }

        public ActiveStatus Status
        {
            get => _status;
            set => _status = value;
        }

        public SPHTransation()
        {
        }
    }
}