namespace Domain.DTO.Response
{
    public class LoanResponseDTO
    {
        public string UserId { get; set; }
        public string BookName { get; set; }
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public Guid BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

