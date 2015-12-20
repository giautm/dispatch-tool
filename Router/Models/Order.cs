namespace GiauTM.CSharp.TikiRouter.Models
{
    class Order
    {
        private string[] mFields;
        private int mIdxBarcode;
        private int mIdxWardId;

        public string Barcode { get { return mFields[mIdxBarcode]; } }
        public string WardId { get { return mFields[mIdxWardId]; } }
        public string[] Fields { get { return mFields; } }

        public Order(string[] fields, int idxBarcode, int idxWardId)
        {
            this.mFields = fields;
            this.mIdxBarcode = idxBarcode;
            this.mIdxWardId = idxWardId;
        }
    }
}