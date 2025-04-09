using Lieferverwaltung;

namespace LieferverwaltungTests
{
    [TestClass]
    public class LieferungTests
    {
        [TestMethod]
        public void Lieferung_kannErstelltWerden()
        {
            // Arrange
            DateOnly datum = DateOnly.FromDateTime(DateTime.Now);
            string sendungsnummer = "HHX05NNW0ZP";
            string plz = "86309";
        
            // Act
            Lieferung l = new Lieferung(datum, sendungsnummer, plz);
        
            // Assert
            Assert.AreEqual(datum, l.Datum);
            Assert.AreEqual(sendungsnummer, l.Sendungsnummer);
            Assert.AreEqual(plz, l.PLZ);
        }
    }
}