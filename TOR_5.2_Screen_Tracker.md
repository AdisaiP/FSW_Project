# TOR 5.2 — Mapping หน้าจอตาม TOR (Mining Account)

> **กรมอุตสาหกรรมพื้นฐานและการเหมืองแร่ (กพร.)**  
> อัปเดต: 26 เมษายน 2569 (อัปเดตกลุ่ม B, C, D, E, F — ครบถ้วนทุกกลุ่ม)  
> Base URL: `http://localhost:5055`

---

## ๕.๒.๑. ส่วนการลงทะเบียนสมัครและบริหารจัดการข้อมูลสมาชิก

**๕.๒.๑.๑.** รองรับการลงทะเบียนสมาชิกได้หลายช่องทาง เช่น ลงทะเบียน Online ผ่านเว็บไซต์ด้วยตนเอง (Self Service) หรือลงทะเบียนข้อมูลโดยเจ้าหน้าที่ดำเนินการให้ (Walk In) หรือผ่านระบบ ThaiID  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/RegisterChannel` (แสดง 3 ช่องทาง: Self-Service, ThaiID, Walk-In)

---

**๕.๒.๑.๒.** สามารถตรวจสอบการลงทะเบียนข้อมูลซ้ำกับที่มีระบบได้  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/RegisterMultiSteps` (Step 1 — ตรวจสอบเลขบัตรซ้ำ mock [`1234567890123`] แจ้งเตือนทันที)

---

**๕.๒.๑.๓.** สามารถแนบเอกสารเพิ่มเติมที่เกี่ยวข้องตามประเภทของสมาชิกได้  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/RegisterMultiSteps` (Step 2 — Dropzone + docHint แสดงรายการเอกสารตามประเภทสมาชิก)

---

## ๕.๒.๒. รองรับการแจ้งลิงก์หรือรหัสยืนยันการลงทะเบียนสมาชิก (Activate) ผ่านอีเมล

หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/VerifyEmailBasic` (OTP 6 หลัก, นับถอยหลัง 150 วิ, ส่งรหัสใหม่) + `http://localhost:5055/Auth/RegisterComplete` (หน้า Success + timeline)

---

## ๕.๒.๓. รองรับการพิสูจน์และยืนยันตัวตนตามประเภทของผู้ใช้งาน

### ๕.๒.๓.๑. การเชื่อมโยงข้อมูลผู้ประกอบการผ่าน i-Industry

**๕.๒.๓.๑(๑)** รองรับการล็อกอินของผู้ประกอบการผ่าน i-Industry และ Redirect มายังระบบ DPIM Portal SSO โดยไม่ต้องล็อกอินอีกครั้ง  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/LoginBasic` (B1 — ปุ่ม i-Industry SSO พร้อม Cover Layout dpim-banner.jpg + dpim-logo.png) + `http://localhost:5055/Auth/SSORedirectIndustry` (B2 — Redirect page countdown + spinner)

---

**๕.๒.๓.๑(๒)** มีระบบการยื่นคำขอและแนบเอกสารประกอบเพื่อขอเปิดสิทธิ์การเข้าใช้งาน  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/AccessRequest` (C1 — ยื่นคำขอสิทธิ์ระบบ + Dropzone + แสดงเลข REF)

---

### ๕.๒.๓.๒. รองรับการเชื่อมโยงข้อมูลเจ้าหน้าที่ กพร./สปอ. ผ่าน i-Industry Officer

**๕.๒.๓.๒(๑)** รองรับการล็อกอินเจ้าหน้าที่ผ่าน i-Industry Officer และ Redirect มายังระบบ  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/LoginBasic` (B1 — ปุ่ม i-Industry Officer SSO) + `http://localhost:5055/Auth/SSORedirectOfficer` (B3 — Redirect page orange theme)

---

**๕.๒.๓.๒(๒)** สามารถตรวจสอบข้อมูลเจ้าหน้าที่ผ่าน API ที่ i-Industry Officer เปิดให้เชื่อมโยงข้อมูลได้  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/SSORedirectOfficer` (B3 — Mock integration placeholder)

---

### ๕.๒.๓.๓. รองรับการยืนยันตัวตนสมาชิกผ่านระบบ ThaiID

หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/RegisterThaiID` (Redirect + spinner countdown) + `http://localhost:5055/Auth/RegisterThaiIDCallback` (แสดงข้อมูลจาก ThaiID + กรอก email/phone/ประเภทสมาชิก)

---

### ๕.๒.๓.๔. คุณลักษณะทั่วไปของระบบ SSO

**๕.๒.๓.๔(๑)** สามารถเชื่อมโยงข้อมูลบัญชีผู้ใช้งานในระบบงานต่าง ๆ ขององค์กร  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/SSOSettings` (แท็บ "บัญชีที่เชื่อมโยง" — เชื่อมผู้ใช้ DPIM กับ i-Industry / ThaiID)

---

**๕.๒.๓.๔(๒)** รองรับการทำงานร่วมกับ Directory Service เช่น Microsoft Active Directory, OpenLDAP, DB  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/SSOSettings` (แท็บ "Directory Service" — LDAP Host, Base DN, Bind User, ทดสอบการเชื่อมต่อ)

---

**๕.๒.๓.๔(๓)** รองรับการยืนยันตัวตนปัจจุบัน (2FA) ผ่าน Google Authenticator / Microsoft Authenticator / e-Mail  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/TwoStepsBasic` (B5 — MFA Tabs: Email OTP 6 หลัก + Google/MS Authenticator TOTP, นับถอยหลัง 150 วิ, Cover Layout)

---

**๕.๒.๓.๔(๔)** รับรองความถูกต้องของอุปกรณ์ที่เข้าใช้งาน (Trusted Device) โดยไม่ต้องยืนยัน 2FA อีกครั้ง  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/TwoStepsBasic` (B5 — Checkbox "จดจำอุปกรณ์นี้ (30 วัน)") + `http://localhost:5055/Admin/MFAPolicy` (F4 — Trusted Device toggle + expiry days)

---

**๕.๒.๓.๔(๕)** รองรับ User Authentication หลายรูปแบบ เช่น e-Mail, User ID  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/LoginBasic` (B1 — ช่อง อีเมล • SSO i-Industry • SSO Officer • ThaiID)

---

**๕.๒.๓.๔(๖)** รองรับมาตรฐาน OpenID Connect (OIDC), OAuth 2.0  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/SSORedirectIndustry` / `SSORedirectOfficer` / `SSORedirectThaiID` (B2/B3/B4 — Mock OIDC/OAuth redirect flow)

---

**๕.๒.๓.๔(๗)** Web Portal บริหารจัดการ User Account จากศูนย์กลาง (สร้าง เพิกถอน Reset รหัสผ่าน กำหนดสิทธิ์)  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/UserManagement` (F1 — CRUD ผู้ใช้ + กำหนดกลุ่ม/บทบาท + Reset Password + Suspend)

---

**๕.๒.๓.๔(๘)** สามารถเชื่อมโยงกับระบบงานต่าง ๆ ภายในองค์กร  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/SSOSettings` (แท็บ "ระบบที่เชื่อมต่อ" — ตาราง Connected Systems + เพิ่ม/แก้ไข/ลบ)

---

**๕.๒.๓.๔(๙)** หน้าจอลงทะเบียนขอใช้ระบบงานสำหรับผู้ใช้งานใหม่ + กระบวนการอนุมัติคำขอ (กรณีไม่อนุมัติต้องแจ้งเหตุผล)  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/AccessRequest` (C1) + `http://localhost:5055/Officer/AccessRequestList` (C2) + `http://localhost:5055/Officer/ReviewAccessRequest/1` (C3 — อนุมัติ/ปฏิเสธ + เหตุผล)

---

**๕.๒.๓.๔(๑๐)** ระบบบริหารจัดการ Privacy Policy & Notice Management + อัพเดทคุณสมบัติผู้ใช้บริการ  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/PrivacyPolicy` (F2 — Version ตาราง, Rich Text Editor, ประวัติ Consent)

---

**๕.๒.๓.๔(๑๑)** ควบคุมและรับรอง Privacy Policy รายบุคคล + กระบวนการให้ความยินยอมใหม่กรณีมีการเปลี่ยนแปลง  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/PrivacyPolicy` (F2 — แท็บ Consent History + Draft/Published/Archived)

---

**๕.๒.๓.๔(๑๒)** ระบบบริหารจัดการความยินยอมในการเก็บข้อมูล Cookie Consent Banner  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/CookieConsent` (F3 — ตั้งค่าข้อความ/ปุ่ม/URL/Position + Live Preview)

---

**๕.๒.๓.๔(๑๓)** ระบบสร้างและควบคุม Multi-Factor Authentication (MFA) เช่น Risk-Based / Location-Based / Trusted Device  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/MFAPolicy` (F4 — Toggle switches Risk-Based, Location-Based, Trusted Device + กำหนดกลุ่มผู้ใช้ที่ต้องใช้ MFA)

---

**๕.๒.๓.๔(๑๔)** ผู้ใช้งานที่มีสิทธิ์สามารถเข้าสู่ระบบผ่าน Single Sign-on เพียงครั้งเดียว  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/LoginBasic` (B1) → `http://localhost:5055/Auth/SSORedirectIndustry` (B2) → `http://localhost:5055/Auth/SSORedirectOfficer` (B3) → `http://localhost:5055/Auth/SSORedirectThaiID` (B4)

---

**๕.๒.๓.๔(๑๕)** ผู้ใช้งานสามารถปรับปรุงข้อมูลส่วนตัวได้ เช่น ชื่อ นามสกุล เบอร์โทรศัพท์ หน่วยงาน  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Users/ViewAccount` (D1 — แก้ไขข้อมูลทั่วไป + ข้อมูลสำคัญ (ต้องยืนยันรหัสผ่าน/OTP))

---

**๕.๒.๓.๔(๑๖)** ผู้ใช้งานที่ลืมรหัสผ่าน สามารถขอ Reset รหัสผ่านผ่านทางมือถือได้  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Auth/ForgotPasswordBasic` (B6 — แท็บ อีเมล + SMS OTP) + `http://localhost:5055/Auth/ResetPasswordBasic` (B7 — Password Strength Indicator)

---

**๕.๒.๓.๔(๑๗)** กำหนดวันใช้งานล่วงหน้า (Activate Date) สำหรับบัญชีที่สร้างไว้แล้ว  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Officer/RegisterUser` (ฟิลด์ "วันที่เปิดใช้งาน" — flatpickr date picker)

---

**๕.๒.๓.๔(๑๘)** ระบบบริหารจัดการดูแลและควบคุมระบบผ่าน Web Browser สำหรับ Administrator  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/UserManagement` + `http://localhost:5055/Admin/SSOSettings` + `http://localhost:5055/Admin/PasswordPolicy` (F1 — Admin Web Portal ครบวงจร)

---

**๕.๒.๓.๔(๑๙)** Administrator เพิ่ม ลด แก้ไข ตั้งค่าระบบงานต่าง ๆ ที่เชื่อมโยง SSO  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/SSOSettings` (แท็บ "OAuth/OIDC" — ตั้งค่า Provider Client ID/Secret/Endpoint + Toggle เปิด/ปิด)

---

**๕.๒.๓.๔(๒๐)** ระบบสามารถ รับ-ส่ง ข้อความหาผู้ใช้งาน เช่น e-Mail  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/EmailNotification` (ตั้งค่า SMTP + Template อีเมล + ประวัติการส่ง + ทดสอบส่ง)

---

**๕.๒.๓.๔(๒๑)** แสดง TodoList สำหรับแจ้งสิ่งที่ต้องดำเนินการเมื่อผู้ใช้งาน Login เข้าสู่ระบบ  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/TodoList` (F9 — รายการ Todo หมวด: คำขอ/ใบรับรอง/นโยบาย/ระบบ + Filter + Mark Done + Add)

---

**๕.๒.๓.๔(๒๒)** ผู้ใช้สามารถกำหนดเมนูที่ชื่นชอบได้  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Users/ViewAccount#favorite-menu` (F10 — แท็บ "เมนูโปรด" Checkbox grid แบ่งหมวด + Preview + บันทึก)

---

**๕.๒.๓.๔(๒๓)** มีการจัดเก็บ Log ด้านต่าง ๆ ที่เกี่ยวข้องกับระบบ พร้อมแบ่งหมวดหมู่ย่อยได้  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/AuditLog` (F5 — DataTable พร้อม Filter Action/ผลลัพธ์, Summary Stats)

---

**๕.๒.๓.๔(๒๔)** สามารถตรวจสอบ Log ย้อนหลังได้สูงสุดไม่น้อยกว่า ๑๐ วัน  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/AuditLog` (F5 — Date range เริ่มต้น 10 วัน flatpickr, Export PDF/Excel)

---

**๕.๒.๓.๔(๒๕)** จัดการผู้ใช้งาน กลุ่มผู้ใช้ สิทธิ์การเข้าถึงระบบงานผ่าน Web Browser  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/UserManagement` (F1 — DataTable ผู้ใช้ + Modal กำหนดกลุ่ม Multi-select + บทบาท + Activate Date)

---

**๕.๒.๓.๔(๒๖)** คุณสมบัติด้านความปลอดภัยและจัดการสิทธิ์ (Password Policy, Logout Timeout, Role/Group, Favorite Menu)  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/PasswordPolicy` (กฎรหัสผ่าน + Account Lockout + Session Timeout + จัดการกลุ่ม/บทบาท)

---

**๕.๒.๓.๔(๒๗)** ตรวจสอบการใช้งาน SSO (Audit) + Export Report (PDF, Excel, Word) + Preview  

รายงานที่ต้องมี:
- สรุปรายงานการออกรหัสผู้ใช้งานสำหรับผู้ใช้ใหม่ตามช่วงเวลา
- สรุปรายการบัญชีผู้ใช้งานที่ใช้งานอยู่
- สรุปรายการบัญชีผู้ใช้งานที่ถูกปิด
- รายชื่อผู้ใช้แยกตามกลุ่มผู้ใช้งานของแต่ละระบบงาน
- สรุปรายการกลุ่มผู้ใช้งานในแต่ละระบบงาน

หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/AuditLog` (F5 — DataTable Audit + Export PDF/Excel) + `http://localhost:5055/Admin/DataAnalyzer` (F8 — Summary Cards + ApexCharts + Top Users)

---

**๕.๒.๓.๔(๒๘)** เครื่องมือสำหรับวิเคราะห์ข้อมูลและแสดงเป็นภาพ Data Analyzer Create Report & Dashboard  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/DataAnalyzer` (F8 — Summary Cards, Bar/Line/Donut ApexCharts, Top Users DataTable)

---

**๕.๒.๓.๔(๒๙)** แสดงคำถามที่พบบ่อย (FAQ) + Admin บริหารจัดการข้อมูลคำถาม-ตอบ  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/FAQ` (F7 — DataTable + Modal เพิ่ม/แก้ไขคำถาม-ตอบ + Rich Text + สถานะ)

---

**๕.๒.๓.๔(๓๐)** ระบบบริหารจัดการผู้ใช้งาน (สร้าง แก้ไข ลบ)  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Admin/UserManagement` (F1 — CRUD ผู้ใช้ครบถ้วน: เพิ่ม/แก้ไข/ระงับ/รีเซ็ตรหัสผ่าน)

---

## ๕.๒.๔. ระบบออกใบรับรองอิเล็กทรอนิกส์ Self-Sign

จัดทำระบบออกใบรับรองแบบ Self-Sign ให้ผู้ใช้งาน (ผู้ประกอบการและเจ้าหน้าที่) เพื่อใช้สำหรับการลงลายมือดิจิทัล  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Users/Certificate` (E1 — สถานะใบรับรอง + ขอออก/ดาวน์โหลด/ยกเลิก)

---

## ๕.๒.๕. User Profile

จัดทำ User Profile ให้ผู้ใช้งานแก้ไขข้อมูลตนเองได้ตามที่ กพร. กำหนด หากเป็นข้อมูลสำคัญต้องมีการยืนยันตัวตนใหม่  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Users/ViewAccount` (D1 — ข้อมูลทั่วไป แก้ไขได้ / ข้อมูลสำคัญ ต้องยืนยันตัวตน) + `http://localhost:5055/Users/ViewSecurity` (D3 — MFA Setup, Trusted Devices, เปลี่ยนรหัสผ่าน)

---

## ๕.๒.๖. บัญชีรายการที่อยู่ (Address Book)

ผู้ใช้งานสามารถจัดทำบัญชีรายการที่อยู่ที่ใช้ติดต่องานได้หลายที่อยู่ และเลือกที่อยู่หลักได้  
หน้าจอตาม TOR : ✅ `http://localhost:5055/Users/ViewAddresses` (D2 — Cards แสดงที่อยู่หลาย รายการ + Badge ที่อยู่หลัก + Modal เพิ่ม/แก้ไข/ลบ + ตั้งเป็นหลัก)

---


*สร้างโดย GitHub Copilot — DPIM Project*
