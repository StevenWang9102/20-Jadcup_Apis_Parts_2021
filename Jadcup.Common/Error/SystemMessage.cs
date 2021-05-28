using Newtonsoft.Json;
using Jadcup.Common.Helper;

namespace Jadcup.Common.Error {
    public class SystemMessage {
        public string Message { get; }
        public string MessageType { get; }

        [JsonConstructor]
        public SystemMessage(string message, SystemMessageType type = SystemMessageType.Error) {
            Message = message;
            MessageType = type.GetStringValue().ToLower();
        }

        // ********************************************************** \\
        // PLEASE KEEP MESSAGES IN ALPHABETICAL ORDER FOR READABILITY \\
        // ********************************************************** \\
        // ALL MESSAGES HERE ARE USER FACING AND MUST BE PRE-APPROVED \\
        // ********************************************************** \\

        public static SystemMessage GenericError() {
            return new SystemMessage("Unable to process request. Please try again.");
        }
        public static SystemMessage IncorrectAdminPermission() {
            return new SystemMessage("Incorrect admin permission. Please contact manager or Jadcup development team.");
        }
        
        public static SystemMessage InvalidResetPasswordToken() {
            return new SystemMessage("Invalid reset password token.");
        }
        public static SystemMessage NotImplemented() {
            return new SystemMessage("Current feature is not implemented. Please contact Jadcup development team.");
        }
        
        public static SystemMessage IncorrectPassword() {
            return new SystemMessage("Incorrect password. Please try again.");
        }
        
        public static SystemMessage UserNotFound() {
            return new SystemMessage("User not exist.");
        }
        
        public static SystemMessage VerifyEmailError() {
            return new SystemMessage("Please verify your email first.");
        }
        
        public static SystemMessage AlreadyVerifyEmailError() {
            return new SystemMessage("Email has been verified.");
        }
        public static SystemMessage UserNameTaken() {
            return new SystemMessage("Username taken. Try another one.");
        }
        
        public static SystemMessage EmailTaken() {
            return new SystemMessage("Email taken. Try another one.");
        }

        public static SystemMessage UserNameNotFound() {
            return new SystemMessage("UserName not found. Try another one.");
        }
        public static SystemMessage DeleteError() {
            return new SystemMessage("Unable to delete. Being used by other.");
        }

        public static SystemMessage ItemNotFound() {
            return new SystemMessage("Item not found. Please try again.");
        }
        
        public static SystemMessage DuplicateError() {
            return new SystemMessage("Duplicated. Please try again.");
        }

        public static SystemMessage InvalidDateTime()
        {
            return new SystemMessage("Invalid DateTime. Please try again.");
        }

        public static SystemMessage OrderNotAllowedUpdate()
        {
            return new SystemMessage("Production Finished. Order cannot be updated.");
        }

        public static SystemMessage NotEnterValidDate()
        {
            return new SystemMessage("Date is required. Please enter a date");
        }
    }
}