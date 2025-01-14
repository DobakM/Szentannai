__version__= "1.0.0"

class Company:
    def __new__(cls, *args, **kwargs):  
        return super().__new__(cls)
    
    def __init__(self, id, office, foreign_office, scope, eu_registration, bank_account, address, email_contact, male_personal, female_personal, capital, time): 
        self.female_personal = female_personal
        self.foreign_office = foreign_office
        self.eu_registration = eu_registration
        self.email_contact = email_contact
        self.male_personal = male_personal
        self.bank_account = bank_account
        self.address = address
        self.capital = capital
        self.office = office
        self.scope = scope
        self.time = time
        self.id = id
        
    def __str__(self):
        pass

    def __repr__(self):
        pass
    
    def __eq__(self, other):
        if isinstance(other, self.__class__):  
            return (self.id.__eq__(other.id))   