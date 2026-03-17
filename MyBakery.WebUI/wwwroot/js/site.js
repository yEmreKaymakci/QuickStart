// Hizmetler kısmındaki Daha Fazla/Daha Az Göster butonu için
function toggleServices() {
    // Sadece 6. sıradan sonrasını temsil eden, bizim atadığımız gizli öğeleri bul
    var extraItems = document.querySelectorAll('.extra-service');
    var btn = document.getElementById('toggleServicesBtn');

    // Eğer buton yoksa veya öğe yoksa fonksiyonu durdur (hata almamak için)
    if (!btn || extraItems.length === 0) return;

    // İlk elemanın gizli (d-none) olup olmadığını kontrol et
    // Eğer gizliyse demek ki "Daha Fazla Göster"e basılmış, eğer görünürse "Daha Az Göster"e basılmıştır.
    var isCurrentlyHidden = extraItems[0].classList.contains('d-none');

    if (isCurrentlyHidden) {
        // GİZLİYDİ -> AÇIYORUZ
        extraItems.forEach(function (item) {
            item.classList.remove('d-none');
        });
        // Butonun yazısını "Daha Az Göster" yap
        btn.innerText = "Daha Az Göster";
    } else {
        // AÇIKTI -> GİZLİYORUZ
        extraItems.forEach(function (item) {
            item.classList.add('d-none');
        });
        // Butonun yazısını "Daha Fazla Göster" yap
        btn.innerText = "Daha Fazla Göster";

        // (İsteğe Bağlı) Kullanıcıyı tekrar hizmetler bölümünün en üstüne yavaşça kaydır
        // document.getElementById('services').scrollIntoView({ behavior: 'smooth' });
    }
}

// Admin
document.addEventListener('DOMContentLoaded', function () {
    const globalModal = document.getElementById('globalTextModal');

    // Eğer sayfada modal yoksa kodu hiç çalıştırma (Hata vermemesi için)
    if (!globalModal) return;

    const modalTitle = document.getElementById('globalModalTitle');
    const modalContent = document.getElementById('globalModalContent');

    // Sayfadaki tüm tıklamaları dinle (Event Delegation)
    document.addEventListener('click', function (e) {

        // 1. Modalı Açma İşlemi
        const triggerBtn = e.target.closest('.show-full-text-btn');
        if (triggerBtn) {
            // Tıklanan yerdeki data özelliklerini al
            const title = triggerBtn.getAttribute('data-title');
            const content = triggerBtn.getAttribute('data-content');

            // Modala verileri bas ve görünür yap
            modalTitle.innerText = title ? title : 'Detay';
            modalContent.innerText = content ? content : 'İçerik bulunamadı.';
            globalModal.classList.remove('hidden');
        }

        // 2. Modalı Kapatma İşlemi
        // Kapat butonlarına veya modalın dışındaki siyah arkaplana tıklanırsa
        if (e.target.closest('#closeGlobalModalBtn') ||
            e.target.closest('#closeGlobalModalBtn2') ||
            e.target === globalModal) {

            globalModal.classList.add('hidden');
        }
    });
});