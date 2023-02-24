using Controller;
using Repo;
using Service;
using System.Windows;
using System.Windows.Navigation;

namespace MedicalCenterProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string USERS_FILE = "../../Resources/txt/Users.txt";
        private const string SEPARATOR = ",";
        private const string FEEDBACK_FILE = "../../Resources/txt/Feedbacks.txt";
        private const string FAQ_FILE = "../../Resources/txt/faq.txt";
        private const string EXAMINATIONS_FILE = "../../Resources/txt/Examinations.txt";
        private const string ROOMOCCUPATION_FILE = "../../Resources/txt/RoomOccupation.txt";
        private const string WORKERS_FILE = "../../Resources/txt/Workers.txt";
        private const string PATIENTS_FILE = "../../Resources/txt/Patients.txt";
        private const string NOTIFICATIONS_FILE = "../../Resources/txt/Notifications.txt";
        private const string VALIDATE_MEDICINES_FILE = "../../Resources/txt/ValidateMedicines.txt";
        private const string MEDICINES_FILE = "../../Resources/txt/Medicines.txt";

        public App()
        {
            var notificationRepository = new NotificationRepository(NOTIFICATIONS_FILE);
            var patientRepository = new PatientRepository(PATIENTS_FILE, SEPARATOR);
            var examinationRepository = new ExaminationRepository(EXAMINATIONS_FILE, SEPARATOR, ROOMOCCUPATION_FILE);
            var workersRepository = new WorkersRepository(WORKERS_FILE, SEPARATOR, USERS_FILE);
            var faqRepository = new FaqRepository(FAQ_FILE);
            var registeredUsers = new UsersRepository(USERS_FILE, SEPARATOR, PATIENTS_FILE);
            var feedbackRepository = new FeedbackRepository(FEEDBACK_FILE);
            var medicineRepository = new MedicineRepository(VALIDATE_MEDICINES_FILE, MEDICINES_FILE, SEPARATOR);

            var notificationService = new NotificationService(notificationRepository);
            var patientService = new PatientService(patientRepository);
            var examinationService = new ExaminationService(examinationRepository);
            var workersService = new WorkersService(workersRepository);
            var faqService = new FaqService(faqRepository);
            var userService = new UserService(registeredUsers);
            var feedbackService = new FeedbackService(feedbackRepository);
            var medicineService = new MedicineService(medicineRepository);

            NotificationController = new NotificationController(notificationService);
            PatientController = new PatientController(patientService);
            ExaminationController = new ExaminationController(examinationService);
            WorkersController = new WorkersController(workersService);
            FaqController = new FaqController(faqService);
            UserController = new UserController(userService);
            FeedbackController = new FeedbackController(feedbackService);
            MedicineController = new MedicineController(medicineService);


        }
        public NotificationController NotificationController { get; private set; }
        public PatientController PatientController { get; private set; }
        public FaqController FaqController { get; private set; }
        public UserController UserController { get; private set; }
        public FeedbackController FeedbackController { get; private set; }
        public WorkersController WorkersController { get; private set; }
        public ExaminationController ExaminationController { get; private set; }
        public MedicineController MedicineController { get; private set; }

    }
}

