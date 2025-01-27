namespace teste03.Models
{
    public class Cabecalho
    {   
        public string area { get; set; }
        public string estado { get; set; }
        public string usuario { get; set; }
        public string empresa   { get; set; }
        public DateTime inicio { get; set; }  
        public DateTime fim { get; set; }
        public DateTime envio { get; set; }
        public string aprovado { get; set; }
        public string aprovacao { get; set; }
        public string cod {  get; set; }
        public string numeroATP { get; set; }
        public string cliente {  get; set; }
        public string endereco { get; set; }
        public string municipio { get; set; }
        public string uf {  get; set; }
        public string areaAT { get; set; }
        public string status {  get; set; }
        public string certi { get; set; }
        public string numeroCert {get; set; }
        public string valorCent { get; set; }
        public string obsCe {  get; set; }
        public string valCabo { get; set; }
        public string obsAndarDoCen {  get; set; }
        public string valAdarDoCen { get; set; }
        public string obsValdenCabo { get; set; }
        public IFormFile img1 { get; set; }
        public string obsImg1 {  get; set; }
    }
}
