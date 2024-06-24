using Twilio.TwiML.Voice;

namespace ECA.API.Models
{
    [Table("mastrep")]
    public partial class MasterRep 
    {
        [Key]
        [StringLength(6)]
        public string NO { get; set; }

        [StringLength(100)]
        public string? NOF { get; set; }

        [StringLength(255)]
        public string? NAME { get; set; }

        [StringLength(255)]
        public string? adress { get; set; }

        [StringLength(255)]
        public string? army_cod { get; set; }

        [StringLength(255)]
        public string? bran_cod { get; set; }

        [StringLength(255)]
        public string? cer_cod { get; set; }

        [StringLength(255)]
        public string? kinde_cod { get; set; }

        [StringLength(255)]
        public string? custom_cod { get; set; }

        [StringLength(255)]
        public string? deg_cod { get; set; }

        [StringLength(255)]
        public string? degkind { get; set; }

        [StringLength(255)]
        public string? degree_cod { get; set; }

        [StringLength(255)]
        public string? govern { get; set; }

        [StringLength(255)]
        public string? relg_cod { get; set; }

        [StringLength(255)]
        public string? job_cod { get; set; }

        [StringLength(255)]
        public string? mang { get; set; }

        [StringLength(255)]
        public string? out_cod { get; set; }

        [StringLength(255)]
        public string? univ_cod { get; set; }

        [StringLength(255)]
        public string? re_cod { get; set; }

        [StringLength(255)]
        public string? social_cod { get; set; }

        public DateTime? b_d { get; set; }

        [StringLength(100)]
        public string? NO_NAT { get; set; }

        [StringLength(100)]
        public string? CARDNO { get; set; }

        public DateTime? C_D { get; set; }

        public DateTime? CE_D { get; set; }

        public DateTime? COU_D { get; set; }

        public DateTime? D_D { get; set; }

        public DateTime? J_D { get; set; }

        public DateTime? RE_D { get; set; }

        [StringLength(8)]
        public string? NO_FROM { get; set; }

        [StringLength(60)]
        public string? govern_cod { get; set; }

        [StringLength(6)]
        public string? govern_cod1 { get; set; }

        [StringLength(100)]
        public string? card_cod { get; set; }

        public short? del { get; set; }

        public DateTime? del_d { get; set; }

        [StringLength(255)]
        public string? B_PLACe { get; set; }

        [StringLength(100)]
        public string? busy { get; set; }

        [StringLength(100)]
        public string? KINDE { get; set; }

        [StringLength(100)]
        public string? job2 { get; set; }

        [StringLength(255)]
        public string? note { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? s { get; set; }

        [StringLength(255)]
        public string? language2 { get; set; }

        public DateTime? modfydate { get; set; }

        [StringLength(255)]
        public string? language1 { get; set; }
        public short? five { get; set; }
        public short? place { get; set; }

        [StringLength(14)]
        public string? phone { get; set; }
        public DateTime? expecteddate { get; set; }

        [StringLength(70)]
        public string? qulativegroup { get; set; }

        [StringLength(50)]
        public string? jobtitles { get; set; }

        [StringLength(75)]
        public string? retirement { get; set; }
        public short? sixfive { get; set; }

        [StringLength(10)]
        public string? mangid { get; set; }

        [StringLength(6)]
        public string? degreeid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? degorder { get; set; }
        public DateTime? deg_date { get; set; }
        public short? receved { get; set; }
        public DateTime? receveddate { get; set; }
        public DateTime? out_date { get; set; }

        [StringLength(6)]
        public string? jopcodid { get; set; }

        [StringLength(100)]
        public string? sec { get; set; }

        [StringLength(100)]
        public string? cent { get; set; }

        [StringLength(100)]
        public string? genmang { get; set; }

        [StringLength(100)]
        public string? mang1 { get; set; }

        [StringLength(100)]
        public string? mang2 { get; set; }

        [StringLength(100)]
        public string? typ_group { get; set; }
        public int? age { get; set; }
        public short? rank { get; set; }
        public short? method { get; set; }
        public short? statusfasic { get; set; }
        public DateTime? founddate { get; set; }
        public int? since { get; set; }
        public short? flag { get; set; }
        public int? level_id { get; set; }

        [StringLength(75)]
        public string? first_deg { get; set; }

        [StringLength(75)]
        public string? first_typdeg { get; set; }
        public DateTime? first_degdate { get; set; }

        [StringLength(120)]
        public string? lastgov { get; set; }
        public short? countsons { get; set; }
        public short? countwives { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? serialemp { get; set; }
        public int? obst_id { get; set; }
        public DateTime? ts_date { get; set; }
        public short? bouncepercent { get; set; }
        public int? userid { get; set; }
        public int? cert_code { get; set; }
        public int? milit_code { get; set; }
        public int? dept_code { get; set; }
        public int? deg_code { get; set; }
        public int? job_grade_code { get; set; }
        public int? job_title_code { get; set; }
        public int? univ_code { get; set; }
        public int? social_status_code { get; set; }
        public int? spec_group_code { get; set; }
        
        [StringLength(10)]
        public string? first_name { get; set; }

        [StringLength(10)]
        public string? second_name { get; set; }

        [StringLength(10)]
        public string? third_name { get; set; }

        [StringLength(10)]
        public string? fourth_name { get; set; }

        [StringLength(100)]
        public string? sector { get; set; }

        [StringLength(100)]
        public string? central { get; set; }
    }
}
